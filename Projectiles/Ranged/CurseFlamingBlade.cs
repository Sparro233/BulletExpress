namespace BulletExpress.Projectiles.Ranged
{
    public class CurseFlamingBlade : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 255;
            Projectile.width = 18;
            Projectile.height = 42;
            Projectile.scale = 1f;
            DrawOriginOffsetY = 0;
            DrawOffsetX = 0;

            Projectile.timeLeft = 42;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            //�䵯��ת,��ͼ�Գ�
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f) ? 1 : -1;

            //Ѱ����Һ��䵯֮����ߣ�ê���䵯������ҵ��ٶ�
            Player player = Main.player[Projectile.owner];
            Projectile.position = player.position + Projectile.velocity * 0f * (200f - Projectile.timeLeft);
            //Ѱ����Һ����֮����ߣ��������������ٶȣ�����ת
            Vector2 v = Vector2.Normalize(Main.MouseWorld - player.Center);
            Vector2 v2 = Vector2.Normalize(Main.MouseWorld - Projectile.Center);
            float rotaion = v.ToRotation();
            if (Vector2.Distance(Projectile.Center, Main.MouseWorld) < 1)
            {
                Projectile.velocity *= 1f;
                Projectile.Center = Main.MouseWorld;
            }
            else
            {
                Projectile.velocity = v2 * 1;
            }

            //�����䵯�����
            Vector2 playerRotatedPoint = player.RotatedRelativePoint(player.MountedCenter, true);

            //��ת�Ͷ���
            float velocityAngle = Projectile.velocity.ToRotation();
            Projectile.rotation = velocityAngle + (Projectile.spriteDirection == -1).ToInt() * MathHelper.Pi;
            Projectile.direction = (Math.Cos(velocityAngle) > 0).ToDirectionInt();

            //��������ֱ�ĩ�˵�λ�á�
            Projectile.position = playerRotatedPoint - Projectile.Size * 0.5f + velocityAngle.ToRotationVector2() * 80f;

            //Sprite ����ҷ���
            Projectile.spriteDirection = Projectile.direction;
            player.ChangeDir(Projectile.direction);

            //���������Ŀ���ֶ�����
            player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();
            player.heldProj = Projectile.whoAmI;
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 8; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Green>(), 0f, 0f, 0, default, 1.5f);
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(8));
                v2 *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = -v2;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 8; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Green>(), 0f, 0f, 0, default, 1.5f);
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(8));
                v2 *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = -v2;
            }
        }
    }
}