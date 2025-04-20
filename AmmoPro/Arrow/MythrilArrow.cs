namespace BulletExpress.AmmoPro.Arrow
{
    public class MythrilArrow: ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 200;

            Projectile.arrow = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 20f)
            {
                Projectile.ai[0] = 20f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;

                if (Projectile.timeLeft % 30 == 0)
                {
                    Vector2 v = new Vector2(0, 0);
                    Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.CursedDartFlame, Projectile.damage / 4, Projectile.knockBack, Projectile.owner);
                }
            }
            if (Main.rand.NextBool(10))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightIII>(), 0f, 0f, 55, default, 1.2f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightIII>(), 0f, 0f, 100, default, 1.2f);
            d.velocity *= 1f;
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.Kill();
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.CursedDartFlame, Projectile.damage / 4, Projectile.knockBack, Projectile.owner);
        }
    }
}