namespace BulletExpress.Projectiles.Ranged
{
    public class ExplodingBowWhiteWing : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 255;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.scale = 1f;
            DrawOriginOffsetY = 0;
            DrawOffsetX = 0;

            Projectile.timeLeft = 64;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            //ǿ��ʹ��ʱ��
            /*player.itemTime = 20;
            player.itemAnimation = 20;
            player.SetDummyItemTime(20);*/
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
                //�䵯�������������ٶ�
                Projectile.velocity *= 1f;
                Projectile.Center = Main.MouseWorld;
            }
            else
            {
                //�����ٶ�
                Projectile.velocity = v2 * 1;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].velocity = Vector2.Normalize(-Projectile.velocity) * 12f;
            NetMessage.SendData(MessageID.SyncPlayer, -1, -1, null, Projectile.owner);
        }
    }
}