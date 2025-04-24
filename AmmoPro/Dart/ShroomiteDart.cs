namespace BulletExpress.AmmoPro.Dart
{
    public class ShroomiteDart : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.FiresFewerFromDaedalusStormbow[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 400;
            Projectile.extraUpdates = 1;
            Projectile.penetrate = 2;
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

            if (Main.rand.NextBool(30))
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(2, -2));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.Mushroom, Projectile.damage * 3, Projectile.knockBack, Projectile.owner);
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
            Projectile.penetrate--;
            if (Projectile.penetrate <= 1)
            {
                Projectile.Kill();
            }
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            return false;
        }
    }
}