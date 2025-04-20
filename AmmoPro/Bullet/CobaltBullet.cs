namespace  BulletExpress.AmmoPro.Bullet
{
	public class CobaltBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.light = 0.2f;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;
            Projectile.penetrate = 4;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            if (Main.rand.NextBool(20))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 55, default, 1.2f);
                d.velocity *= 0f; 
                d.noGravity = true;
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
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-6, 6), Main.rand.NextFloat(6, -6));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.Muramasa, Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.tileCollide = false;
            for (int i = 0; i < 4; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-6, 6), Main.rand.NextFloat(6, -6));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.Muramasa, Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
        }
    }
}