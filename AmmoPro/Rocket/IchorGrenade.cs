namespace BulletExpress.AmmoPro.Rocket
{
    public class IchorGrenade : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.timeLeft = 200;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.1f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 20f)
            {
                Projectile.ai[0] = 20f;
                Projectile.velocity.Y += 0.2f;
                Projectile.velocity *= 0.99f;
            }
            if (Projectile.velocity.X > -0.8f && Projectile.velocity.X < 0.8f && Projectile.velocity.Y > -0.8f && Projectile.velocity.Y < 0.8f)
            {

            }
            else
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IchorTorch, 0f, 0f, 0, default, 1f);
                d.noGravity = true;
                d.velocity *= 0f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                Projectile.velocity.X = oldVelocity.X * -0.4f;
            }
            if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                Projectile.velocity.Y = oldVelocity.Y * -0.4f;
            }
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<GrenadeBoom>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);

            for (int i = 0; i < 2; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(10, -10));
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v, ProjectileID.GoldenShowerFriendly, Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 1);
            }

            for (int j = 0; j < 8; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IchorTorch, 0f, 0f, 100, default, 1.5f);
                Vector2 v1 = Projectile.velocity;
                Vector2 v2 = v1.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = v2;
                d.velocity *= 0.5f;

                Dust dI = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IchorTorch, 0f, 0f, 100, default, 2.5f);
                Vector2 vI = Projectile.velocity;
                Vector2 vII = vI.RotatedByRandom(MathHelper.ToRadians(40));
                vII *= 1f - Main.rand.NextFloat(0.9f);
                dI.velocity = vII;
                dI.velocity *= 0.5f;
            }
            SoundEngine.PlaySound(SoundID.NPCHit13, Projectile.position);
        }
    }
}