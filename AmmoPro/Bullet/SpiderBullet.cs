namespace BulletExpress.AmmoPro.Bullet
{
	public class SpiderBullet : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;

            Projectile.timeLeft = 50;
            Projectile.extraUpdates = 1;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.Kill();
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.2f);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v2, ProjectileID.BabySpider, Projectile.damage / 2, Projectile.knockBack / 2, Projectile.owner);
            }
            SoundEngine.PlaySound(SoundID.Item17, Projectile.position);
        }
    }
}