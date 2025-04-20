namespace BulletExpress.AmmoPro.Rocket.Sakura
{
    public class VortexPowder : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.light = 0.2f;

            Projectile.timeLeft = 300;

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
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Powder>(), 0f, 0f, 0, default, 0.8f);
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
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<SakuraBoom>(), Projectile.damage / 3, Projectile.knockBack = 0, Projectile.owner);
            for (int i = 0; i < 4; i++)
            {
                Vector2 v2 = new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-10, -8));
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v2, ModContent.ProjectileType<PinkCrystal>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 1);
            }

            for (int j = 0; j < 2; j++)
            {
                var d = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f, Projectile.position.Y + 3f) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, ModContent.DustType<IDA.Powders.ShyPink>(), 0f, 0f, 100);
                d.velocity *= 2f;
            }
            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
        }
    }
}