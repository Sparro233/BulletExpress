namespace BulletExpress.Projectiles.Horti
{
    public class MagicLetterOpener : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 55;
            Projectile.width = 12;
            Projectile.height = 12;
            DrawOffsetX = -6;

            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.02f;

            Projectile.ai[0]++;
            if (Projectile.ai[0] > 20f && Projectile.timeLeft >= 420)
            {
                Projectile.velocity *= 0.93f;
            }

            if (Projectile.ai[0] > 40f && Projectile.timeLeft >= 420)
            {
                Projectile.velocity *= 0.93f;
                int index = Projectile.FindTargetWithLineOfSight(320);
                if (index >= 0)
                {
                    NPC npc = Main.npc[index];
                    Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 20f;
                } 
            }

            if (Projectile.timeLeft <= 420)
            {
                Projectile.velocity.Y += 0.3f;
            }
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }
    }
}