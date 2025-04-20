namespace BulletExpress.Projectiles.Summon
{
    public class BirchRhythm : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Summon";
        public override void SetStaticDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            //��ʹ���䵯ʹ�ñ�����ײ��⣬���������Ӧ��ҩ����
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
            //����������һ�����˱���ÿ֡�������� ��Projectile.extraUpdates = 1������� 30 ���� 1 �롣
            if (!owner.channel || ChargeTime >= 30)
            { 
                //��ԭ����� AI ���С�
                return true;
            }
            //ÿ?�̳��� 1 �Ρ�
            if (++ChargeTime % 20 == 0) 
                Projectile.WhipSettings.Segments++;

            //������������ӵ� 0.75 ���Գ����硣
            Projectile.WhipSettings.RangeMultiplier += 1 / 120f;
            Projectile.damage += 20;
            Projectile.velocity *= 1.01f;

            //�ڳ��ʱ���ö�������Ʒ��ʱ����
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
                //�ֱ��Ĵ�С��������Ϊ��λ��
                Rectangle frame = new Rectangle(0, 0, 10, 26);
                //������ƿ�ʼλ�õ�ƫ��������ͼ������Ͻǿ�ʼ������
                Vector2 origin = new Vector2(5, 8); 
                float scale = 1;

                if (i == list.Count - 2)
                {
                    //���Ǳ��ӵ�ͷ������Ҫ���� sprite ���ҳ���Щֵ
                    //�� Sprite ������֡��ʼ�ľ���
                    frame.Y = 74;
                    //��ܵĸ߶�
                    frame.Height = 18;

                    //Ϊ�˻�ø��г��������ۣ���������ȫ��չʱ������Ŵ���ӵļ�ˣ�������ʱ��������С���ӵļ�ˡ�
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
                //���䵯�ľ��鳯�£����PIOVER2����У����ת��
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
