namespace BulletExpress.Projectiles.Ranged
{
    public class Tangerine : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;

            Projectile.timeLeft = 1200;
            Projectile.penetrate = 32;

            Projectile.friendly = true;
            base.SetDefaults();
        }
        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.1f;

            int index = Projectile.FindTargetWithLineOfSight(320);
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity += (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 1f;

                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y -= 0.01f;

                if (Main.rand.NextBool(5))
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Vector2 v = new Vector2(Main.rand.NextFloat(-8, 8), Main.rand.NextFloat(8, -8));
                        Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<TCJuice>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                    }
                }
            }
            else
            {
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.6f;
            }

            if (Main.rand.NextBool(5))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.CoconutWater>(), 0f, 0f, 100, default, 1.8f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 6; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.CoconutWater>(), 0f, 0f, 100, default, 1.8f);
                d.velocity *= 3f;
                d.noGravity = true;
            }
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                Projectile.velocity.X = oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                Projectile.velocity.Y = oldVelocity.Y;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            return false;
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(10, -10));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<TCJuice>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
        }
    }
}