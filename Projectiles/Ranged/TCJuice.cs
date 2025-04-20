namespace BulletExpress.Projectiles.Ranged
{
    public class TCJuice : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.timeLeft = 600;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;

            Projectile.friendly = true;
            Projectile.hostile = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.velocity.Y *= 0.99f;
            Projectile.velocity.Y += 0.2f;

            if (Main.rand.NextBool(5))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.CoconutWater>(), 0f, 0f, 100, default, 1.8f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }
    }
}