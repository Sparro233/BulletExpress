namespace BulletExpress.AmmoPro.Arrow
{
    public class DecorationArrow : ModProjectile
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
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.ai[0] = 30f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
            }
            if (Projectile.timeLeft % 20 == 0)
            {
                Vector2 v = new Vector2(0, 0);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.OrnamentFriendly, Projectile.damage / 4, Projectile.knockBack, Projectile.owner);
            }
            if (Projectile.timeLeft % 10 == 0)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust, 0f, 0f, 55, default, 1.2f);
                d.velocity.Y *= 0.5f;
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.Kill();
        }

        public override void OnKill(int timeLeft)
        {
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.YellowStarDust, 0f, 0f, 100, default, 1.2f);
            d.velocity.Y *= 0.5f;

            SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
        }
    }
}