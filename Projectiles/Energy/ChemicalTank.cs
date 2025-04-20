namespace BulletExpress.Projectiles.Energy
{
    public class ChemicalTank : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Energy";
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.width = 32;
            Projectile.height = 24;

            Projectile.timeLeft = 400;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.02f;
            Projectile.ai[0]++;
            if (Projectile.ai[0] > 20f)
            {
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.2f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 12; i++)
            {
                float C = MathHelper.TwoPi * Main.rand.NextFloat(1f, 2f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(4f, 8f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;

                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, CV, 513, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            for (int i = 0; i < 4; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                d.velocity.Y *= 1.4f;
            }
            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 13, 0f, 0f, 0, default, 2f);
                d.velocity.Y *= 3f;
            }
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
        }
    }
}