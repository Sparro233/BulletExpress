namespace BulletExpress.Projectiles.Ranged
{
    public class Turbulence : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 200;
            Projectile.width = 10;
            Projectile.height = 10;
            DrawOffsetX = -6;
            DrawOriginOffsetY = -6;

            Projectile.timeLeft = 200;
            Projectile.penetrate = 6;
            Projectile.localNPCHitCooldown = 60;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.velocity.Y *= 0.99f;
            Projectile.velocity.Y -= 0.01f;
            Projectile.alpha -= 10;
            if (Projectile.alpha < 15)
            {
                Projectile.alpha = 15;
            }
            int index = Projectile.FindTargetWithLineOfSight(320);
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity += (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 1f;
            }
            if (Projectile.velocity.Y > 2f)
            {
                Projectile.velocity.Y = 2f;
            }
            if (Projectile.velocity.Y > -2f)
            {
                Projectile.velocity.Y = -2f;
            }
        }

        public override void OnKill(int timeLeft)
        {
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.HarmonicStar>(), 0f, 0f, 0, default, 2f);
        }
    }
}