namespace BulletExpress.Projectiles.Ranged
{
    public class Moerjiekos : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 0;
            Projectile.width = 0;
            Projectile.height = 42;
            Projectile.scale = 1.2f;
            DrawOriginOffsetY = -22;
            DrawOffsetX = 0;

            Projectile.timeLeft = 32;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            float v = Projectile.velocity.ToRotation();
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f) ? 1 : -1;
            Projectile.position = player.position + Projectile.velocity * 0f * (200f - Projectile.timeLeft);

            Vector2 unit = Vector2.Normalize(Main.MouseWorld - player.Center);
            float rotaion = unit.ToRotation();
            /*player.itemTime = 20;
            player.itemAnimation = 20;
            player.SetDummyItemTime(20);*/
            player.direction = Main.MouseWorld.X < player.Center.X ? -1 : 1;
            player.itemRotation = (float)Math.Atan2(rotaion.ToRotationVector2().Y * player.direction, rotaion.ToRotationVector2().X * player.direction);
            Vector2 unit2 = Vector2.Normalize(Main.MouseWorld - Projectile.Center);

            if (Vector2.Distance(Projectile.Center, Main.MouseWorld) < 1)
            {
                Projectile.velocity *= 1f;
                Projectile.Center = Main.MouseWorld;
            }
            else
            {
                Projectile.velocity = unit2 * 1;
            }
        }

        // </summary> /// <param name="lightColor">用来影响光照的颜色。</param>
        // <returns>返回true表示此方法已经处理了绘制，不再重复绘制。</returns>
        public override bool PreDraw(ref Color lightColor)
        {
            // 计算绘制原点，以便在旋转和缩放时以中心为基准
            Vector2 drawOrigin = new(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            // 遍历所有旧位置以绘制轨迹
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                // 计算当前绘制位置，考虑屏幕位置和贴图的偏移
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                // 计算当前颜色，逐渐减少透明度以创建轨迹效果
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                // 绘制当前弹幕贴图，应用旋转和缩放
                Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            // 返回true以指示绘制已经处理
            return true;
        }
        // 我想怎么写，就怎么写🧐☝️

        public override void OnKill(int timeLeft)
        {
            if (Projectile.owner == Main.myPlayer)
            {
                Vector2 VI = new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-1, -1));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, VI, ModContent.ProjectileType<Projectiles.Ranged.MJK>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
        }
    }
}