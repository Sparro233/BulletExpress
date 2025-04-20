namespace BulletExpress.AmmoPro.Bullet
{
    public class HorizonTearI : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 10;
            Projectile.height = 10;

            Projectile.timeLeft = 20;
            Projectile.penetrate = 6;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Projectile.velocity *= 0.9f;
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.FlawlessI>(), 0f, 0f, 100, default, 1.5f);
            d.velocity.X = 0f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.soundDelay == 0)
            {
                SoundStyle Sound = new SoundStyle($"{nameof(BulletExpress)}/IDB/Ogg/EnhancedEnemyimpact1")
                {
                    Volume = 0.4f,
                    PitchVariance = 0.1f,
                };
                SoundEngine.PlaySound(Sound);
            }
        }
    }
}