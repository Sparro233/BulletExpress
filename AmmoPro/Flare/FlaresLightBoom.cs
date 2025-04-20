namespace BulletExpress.AmmoPro.Flare
{
    public class FlaresLightBoom : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Projectile.width = 720;
            Projectile.height = 720;
            Projectile.light = 4f;

            Projectile.timeLeft = 10;
            Projectile.penetrate = 20;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }
    }
}