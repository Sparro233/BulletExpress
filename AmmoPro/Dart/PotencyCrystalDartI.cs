namespace BulletExpress.AmmoPro.Dart
{ 
    public class PotencyCrystalDartI : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 155;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 1200;
            Projectile.extraUpdates = 1;
            Projectile.penetrate = 6;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            if (Projectile.ai[0] >= 60f)
            {
                Projectile.ai[0] = 60f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
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
            Vector2 v = Projectile.velocity;
            Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
            v2 *= 1f - Main.rand.NextFloat(0.2f);
            Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, -v2, ProjectileID.CrystalDart, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 1);
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
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            return false;
        }

    }
}