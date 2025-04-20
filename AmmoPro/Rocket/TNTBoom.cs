namespace BulletExpress.AmmoPro.Rocket
{
    public class TNTBoom : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 16 * 20;
            Projectile.height = 16 * 20;

            Projectile.timeLeft = 10;
            Projectile.penetrate = 20;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.damage = (int)(Projectile.damage * 0.5f);
        }
    }
}