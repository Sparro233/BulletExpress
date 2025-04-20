namespace BulletExpress.Projectiles.Ranged
{
    public class ArtificialDesert : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.timeLeft = 3000;
            Projectile.extraUpdates = 1;
            Projectile.penetrate = -1;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();

            Projectile.velocity.Y *= 0.99f;
            Projectile.velocity.Y -= 0.01f;

            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 1200f)
            {
                Projectile.velocity *= 0f;
            }
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 1600f)
            {
                if (Main.rand.NextBool(2))
                {
                    Vector2 v = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(-4, -2));
                    Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v, 42, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 1);
                }
            }

            if (Main.rand.NextBool(5))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.CoconutWater>(), 0f, 0f, 100, default, 1.8f);
                d.velocity.Y *= 0.1f;
                d.noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                Projectile.velocity.X = oldVelocity.X = 0f;
            }
            if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                Projectile.velocity.Y = oldVelocity.Y = 0f;
            }
            return false;
        }
    }
}