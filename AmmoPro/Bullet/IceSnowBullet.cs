namespace BulletExpress.AmmoPro.Bullet
{
	public class IceSnowBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.light = 0.2f;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
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
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(44, 300);
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 80, 0f, 0f, 55, default, 1f);
            d.velocity *= 3f;
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(44, 600);
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 80, 0f, 0f, 55, default, 1f);
            d.velocity *= 3f;
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);
        }
    }
}