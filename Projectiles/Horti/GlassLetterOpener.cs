namespace BulletExpress.Projectiles.Horti
{
    public class GlassLetterOpener : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 155;
            Projectile.width = 12;
            Projectile.height = 12;
            DrawOffsetX = -6;

            Projectile.timeLeft = 600;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += 0.2f;

            Projectile.ai[0]++;
            if (Projectile.ai[0] > 20f)
            {
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.3f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);

            for (int j = 0; j < 3; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 13, 0f, 0f, 0, default, 1.8f);
                d.noGravity = true;
                d.velocity *= 3f;
            }            
            
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
        }
    }
}