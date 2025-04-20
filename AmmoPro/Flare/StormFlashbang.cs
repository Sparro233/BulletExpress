namespace BulletExpress.AmmoPro.Flare
{
    public class StormFlashbang : ModProjectile
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
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;

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

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Type].Value;
            var rot = Projectile.rotation + (float)Math.PI / 2f;
            Main.spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition, null, Color.White, rot,
                tex.Size() / 2f, Projectile.scale, 0, 0);
            return false;
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
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);
            Projectile.timeLeft -= 20;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.velocity = (target.Center - Projectile.Center) * 0.2f;
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);
            Projectile.timeLeft -= 20;
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<FlaresLightBoom>(), Projectile.damage * 5, Projectile.knockBack = 0, Projectile.owner);

            for (int i = 0; i < 8; i++)
            {
                Vector2 v1 = Projectile.velocity;
                Vector2 v2 = v1.RotatedByRandom(MathHelper.ToRadians(180));
                v2 *= 1f - Main.rand.NextFloat(0.2f);
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v2, 731, Projectile.damage * 2, Projectile.knockBack, Main.myPlayer, 0, 1);
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