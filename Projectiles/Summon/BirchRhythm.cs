namespace BulletExpress.Projectiles.Summon
{
    public class BirchRhythm : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Summon";
        public override void SetStaticDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            //这使得射弹使用鞭子碰撞检测，并允许对其应用药剂。
            ProjectileID.Sets.IsAWhip[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 155;
            Projectile.WhipSettings.Segments = 18;
            Projectile.WhipSettings.RangeMultiplier = 1f;
            Projectile.DefaultToWhip();
        }

        public override bool PreAI()
        {
            Player owner = Main.player[Projectile.owner];
            //与其他鞭子一样，此鞭子每帧更新两次 （Projectile.extraUpdates = 1），因此 30 等于 1 秒。
            if (!owner.channel || ChargeTime >= 30)
            { 
                //让原版鞭子 AI 运行。
                return true;
            }
            //每?刻充能 1 段。
            if (++ChargeTime % 20 == 0) 
                Projectile.WhipSettings.Segments++;

            //将续航里程增加到 0.75 倍以充满电。
            Projectile.WhipSettings.RangeMultiplier += 1 / 120f;
            Projectile.damage += 20;
            Projectile.velocity *= 1.01f;

            //在充电时重置动画和物品计时器。
            owner.itemAnimation = owner.itemAnimationMax;
            owner.itemTime = owner.itemTimeMax;

            return false;
        }

        private float Timer
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        private float ChargeTime
        {
            get => Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }

        private void DrawLine(List<Vector2> list)
        {
            Texture2D texture = TextureAssets.FishingLine.Value;
            Rectangle frame = texture.Frame();
            Vector2 origin = new Vector2(frame.Width / 2, 2);

            Vector2 pos = list[0];
            for (int i = 0; i < list.Count - 1; i++)
            {
                Vector2 element = list[i];
                Vector2 diff = list[i + 1] - element;

                float rotation = diff.ToRotation() - MathHelper.PiOver2;
                Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
                Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

                Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

                pos += diff;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            List<Vector2> list = new List<Vector2>();
            Projectile.FillWhipControlPoints(Projectile, list);

            DrawLine(list);

            SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Texture2D texture = TextureAssets.Projectile[Type].Value;

            Vector2 pos = list[0];

            for (int i = 0; i < list.Count - 1; i++)
            { 
                //手柄的大小（以像素为单位）
                Rectangle frame = new Rectangle(0, 0, 10, 26);
                //玩家手牌开始位置的偏移量，从图像的左上角开始测量。
                Vector2 origin = new Vector2(5, 8); 
                float scale = 1;

                if (i == list.Count - 2)
                {
                    //这是鞭子的头。您需要测量 sprite 以找出这些值
                    //从 Sprite 顶部到帧开始的距离
                    frame.Y = 74;
                    //框架的高度
                    frame.Height = 18;

                    //为了获得更有冲击力的外观，当鞭子完全伸展时，它会放大鞭子的尖端，当卷曲时，它会缩小鞭子的尖端。
                    Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
                    float t = Timer / timeToFlyOut;
                    scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));
                }
                else if (i > 10)
                {
                    frame.Y = 58;
                    frame.Height = 16;
                }
                else if (i > 5)
                {
                    frame.Y = 42;
                    frame.Height = 16;
                }
                else if (i > 0)
                {
                    frame.Y = 26;
                    frame.Height = 16;
                }

                Vector2 element = list[i];
                Vector2 diff = list[i + 1] - element;
                //此射弹的精灵朝下，因此PIOVER2用于校正旋转。
                float rotation = diff.ToRotation() - MathHelper.PiOver2; 
                Color color = Lighting.GetColor(element.ToTileCoordinates());

                Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, flip, 0);

                pos += diff;
            }
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(44, 300);
            target.AddBuff(69, 300);
            target.AddBuff(203, 300);
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(44, 600);
            target.AddBuff(69, 600);
            target.AddBuff(203, 600);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            Projectile.damage = (int)(Projectile.damage * 0.8f);
        }
    }
}
