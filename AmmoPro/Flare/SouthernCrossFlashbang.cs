namespace BulletExpress.AmmoPro.Flare
{
    public class SouthernCrossFlashbang : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.light = 1.5f;

            Projectile.timeLeft = 140;
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.ai[0] = 30f;
                Projectile.velocity.Y += 0.2f;
                Projectile.velocity.Y *= 0.99f;
            }
            if (Main.rand.NextBool(5))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustType<IDA.Powders.Flawless>(), 0f, 0f, 100, default, 1f);
                d.velocity *= 0.25f;
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

            Projectile.timeLeft -= 70;
            Projectile.velocity.Y -= 0.6f;

            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(ModContent.BuffType<IDA.Buffs.KillTheSoCalledGods>(), 300);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.timeLeft -= 20;
            Projectile.velocity = (target.Center - Projectile.Center) * 0.2f;
            target.AddBuff(ModContent.BuffType<IDA.Buffs.KillTheSoCalledGods>(), 600);
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<FlaresLightBoom>(), Projectile.damage * 5, Projectile.knockBack = 0, Projectile.owner);

            for (int i = 0; i < 8; i++)
            {
                float C = MathHelper.TwoPi * Main.rand.NextFloat(2f, 8f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(4f, 12f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, CV, ModContent.ProjectileType<Projectiles.Ranged.Thermit>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 1);
            }


            for (int j = 0; j < 20; j++)
            {
                float C = MathHelper.TwoPi * Main.rand.NextFloat(2f, 8f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(4f, 12f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.FlawlessI>(), CV * Main.rand.NextFloat(2f, 4f));
                d.scale = 1.5f;
            }

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}