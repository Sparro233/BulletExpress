namespace BulletExpress.Projectiles.Ranged
{
	public class LotusSeedBoom : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 3;
            Projectile.height = 3;

            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 2;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            // Ðý×ª
            Projectile.rotation += Projectile.velocity.X * 0.03f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Type].Value;
            var rot = Projectile.rotation + (float)Math.PI / 2f;
            Main.spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition, null, Color.White, rot,
                tex.Size() / 2f, Projectile.scale, 0, 0);
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<LotusSeedExplode>()/*ProjectileID.DD2ExplosiveTrapT3Explosion*/, Projectile.damage * 3, Projectile.knockBack, Projectile.owner);

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position); SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}