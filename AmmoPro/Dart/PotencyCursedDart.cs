namespace BulletExpress.AmmoPro.Dart
{
    public class PotencyCursedDart : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 200;            
            Projectile.extraUpdates = 1;
            Projectile.penetrate = 3;
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
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
            }
            if (Main.rand.NextBool(10))
            {
                Vector2 v = new Vector2(0, 0);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.CursedDartFlame, Projectile.damage, Projectile.knockBack, Projectile.owner);
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
            if (Projectile.penetrate >= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 v = Projectile.velocity;
                    Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                    v2 *= 1f - Main.rand.NextFloat(0.2f);
                    Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, ProjectileID.CursedDartFlame, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
                }
            }
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightIII>(), 0f, 0f, 100, default, 3f);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if (Projectile.penetrate >= 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 v = Projectile.velocity;
                    Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                    v2 *= 1f - Main.rand.NextFloat(0.2f);
                    Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, ProjectileID.CursedDartFlame, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.penetrate >= 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 v = Projectile.velocity;
                    Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                    v2 *= 1f - Main.rand.NextFloat(0.2f);
                    Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, ProjectileID.CursedDartFlame, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
                }
            }
        }
    }
}