namespace BulletExpress.AmmoPro.Rocket
{
    public class GoldIngot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 20;
            Projectile.height = 20;

            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.03f;

            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 20f)
            {
                Projectile.ai[0] = 20f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.4f;
            }

            if (Main.rand.NextBool(5))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 55, default, 1f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<GrenadeBoom>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            for (int j = 0; j < 16; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2.5f);
                Vector2 v1 = Projectile.velocity;
                Vector2 v2 = v1.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = v2;
                d.velocity *= 0.5f;
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(72, 600);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<GrenadeBoom>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            for (int j = 0; j < 16; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2.5f);
                Vector2 v1 = Projectile.velocity;
                Vector2 v2 = v1.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = v2;
                d.velocity *= 0.5f;
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}