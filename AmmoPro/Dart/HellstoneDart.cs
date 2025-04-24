namespace BulletExpress.AmmoPro.Dart
{
    public class HellstoneDart : ModProjectile
    {
        public override void SetDefaults()
        {
            AIType = ProjectileID.NailFriendly;
            Projectile.aiStyle = 93;

            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.penetrate = -1;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            //base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;

            /*Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.ai[0] = 30f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
            }*/
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
            v = v.RotatedBy(MathHelper.PiOver4);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<Projectiles.Ranged.DaylightExplodes>(), Projectile.damage * 2, Projectile.knockBack, Projectile.owner);
        }
    }
}
