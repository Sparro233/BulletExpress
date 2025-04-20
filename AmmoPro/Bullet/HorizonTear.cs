namespace BulletExpress.AmmoPro.Bullet
{
    public class HorizonTear : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 10;
            Projectile.height = 10;

            Projectile.timeLeft = 10;
            Projectile.penetrate = 2;
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
            Projectile.velocity *= 0.7f;
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.FlawlessI>(), 0f, 0f, 85, default, 1.2f);
            d.velocity.Y = 0f;
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