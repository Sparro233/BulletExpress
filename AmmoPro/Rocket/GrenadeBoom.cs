namespace BulletExpress.AmmoPro.Rocket
{
    public class GrenadeBoom : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 16 * 10;
            Projectile.height = 16 * 10;

            Projectile.timeLeft = 10;
            Projectile.penetrate = -1;

            Projectile.friendly = true;
            //Projectile.hostile = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }
    }
}