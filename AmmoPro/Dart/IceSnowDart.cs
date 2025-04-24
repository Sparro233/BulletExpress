namespace BulletExpress.AmmoPro.Dart
{
	public class IceSnowDart : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 15;
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.light = 0.2f;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.ai[0] = 30f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 80, 0f, 0f, 55, default, 1f);
            d.velocity *= 3f;
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(44, 600);
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 80, 0f, 0f, 55, default, 1f);
            d.velocity *= 3f;
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);
        }
    }
}