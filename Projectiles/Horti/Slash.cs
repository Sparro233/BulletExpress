namespace BulletExpress.Projectiles.Horti
{
    public class Slash : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 200;
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.scale = 1.2f;
            DrawOriginOffsetY = 6;

            Projectile.timeLeft = 12;
            Projectile.penetrate = 20;
            Projectile.localNPCHitCooldown = 12;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            float v = Projectile.velocity.ToRotation();
            Projectile.rotation = v + 0.78f;
            Player player = Main.player[Projectile.owner];
            Projectile.velocity *= 0.96f;

            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            if (Projectile.ai[0] >= 12f)
                Projectile.Kill();

            if (Projectile.timeLeft == 12)
            {
                SoundStyle impactSound = new SoundStyle($"{nameof(BulletExpress)}/IDB/Ogg/attack_slash_01")
                {
                    Volume = 0.2f,
                    PitchVariance = 0.08f,
                };
                SoundEngine.PlaySound(impactSound);
            }
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);
    }
}