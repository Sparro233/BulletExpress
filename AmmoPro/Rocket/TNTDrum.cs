namespace BulletExpress.AmmoPro.Rocket
{
    public class TNTDrum : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 26;
            Projectile.height = 32;

            Projectile.timeLeft = 400;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            /*float v = Projectile.velocity.ToRotation();
            Projectile.rotation = v + 3.14f;*/
            Projectile.rotation += Projectile.velocity.X * 0.1f;

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 20f)
            {
                Projectile.ai[0] = 20f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.4f;
            }

            if (Main.rand.NextBool())
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1f);
                d.noGravity = true;
                d.scale = 0.1f + Main.rand.Next(5) * 0.1f;
                d.fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
                d.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;

                Dust d2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1f);
                d2.noGravity = true;
                d2.scale = 1f + Main.rand.Next(5) * 0.1f;
                d2.position = Projectile.Center + new Vector2(1, 0).RotatedBy(Projectile.rotation - 2.1f, default) * 10f;
            }
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<TNTBoom>(), Projectile.damage / 2, Projectile.knockBack = 0, Projectile.owner);

            for (int i = 0; i < 20; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                d.velocity *= 2f;

                Dust d1 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 3.5f);
                d1.velocity *= 6f;

                Dust d2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                d2.velocity *= 4f;
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}