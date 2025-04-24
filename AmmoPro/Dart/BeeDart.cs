namespace BulletExpress.AmmoPro.Dart
{
    public class BeeDart : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 400;

            Projectile.friendly = true;
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
            for (int i = 0; i < 3; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(4, -4));
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v, ProjectileID.Bee, Projectile.damage / 2, Projectile.knockBack * 2, Main.myPlayer, 0, 1);
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(4, -4));
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v, ProjectileID.Bee, Projectile.damage / 2, Projectile.knockBack * 2, Main.myPlayer, 0, 1);
            }
            Projectile.Kill();
        }
    }
}