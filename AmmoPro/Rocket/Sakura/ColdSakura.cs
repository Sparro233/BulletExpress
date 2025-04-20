namespace BulletExpress.AmmoPro.Rocket.Sakura
{
    public class ColdSakura : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Projectile.width = 10;
            Projectile.height = 10;
            DrawOffsetX = -6;
            DrawOriginOffsetY = -6;

            Projectile.timeLeft = 1800;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X * 0.1f;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
            Projectile.velocity.Y += 0.2f;
            Projectile.velocity *= 0.97f;
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.PrepareBombToBlow();
            }
            else
            {
                if (Projectile.velocity.X > -0.2f && Projectile.velocity.X < 0.2f && Projectile.velocity.Y > -0.2f && Projectile.velocity.Y < 0.2f)
                {
                    Projectile.alpha += 2;
                    if (Projectile.alpha > 200)
                    {
                        Projectile.alpha = 200;
                    }
                }
                else
                {
                    Projectile.alpha = 0;
                    Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Powder>(), 0f, 0f, 0, default, 0.8f);
                    d.velocity *= 0f;
                }
            }
            int index = Projectile.FindTargetWithLineOfSight(160);
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f;
                Projectile.timeLeft = 60;
            }
            if (Projectile.velocity.X > -0.1f && Projectile.velocity.X < 0.1f)
            {
                Projectile.velocity.X = 0f;
            }
            if (Projectile.velocity.Y > -0.1f && Projectile.velocity.Y < 0.1f)
            {
                Projectile.velocity.Y = 0f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = oldVelocity.X * -0.4f;
            }
            if (Projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 0.7f)
            {
                Projectile.velocity.Y = oldVelocity.Y * -0.4f;
            }
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<SakuraBoom>(), Projectile.damage * 3, Projectile.knockBack = 0, Projectile.owner);
            for (int i = 0; i < 4; i++)
            {
                Vector2 v2 = new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-10, -8));
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v2 * 2, ModContent.ProjectileType<PinkCrystal>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 1);
            }
            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Powder>(), 0f, 0f, 100, default, 3f);
                d.noGravity = true;
                d.velocity *= 4f;
            }
            Dust d2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Flawless>(), 0f, 0f, 0, default, 1f);
            d2.velocity *= 0.25f;
            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
        }
    }
}