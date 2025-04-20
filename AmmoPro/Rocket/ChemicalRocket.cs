namespace BulletExpress.AmmoPro.Rocket
{
    public class ChemicalRocket : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 2)
            {
                Projectile.PrepareBombToBlow();
            }
            else
            {
                if (Math.Abs(Projectile.velocity.X) >= 2f || Math.Abs(Projectile.velocity.Y) >= 2f)
                {
                    float posOffsetX = 0f;
                    float posOffsetY = 0f;

                    posOffsetX = Projectile.velocity.X * 0.5f;
                    posOffsetY = Projectile.velocity.Y * 0.5f;

                    Dust d = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f,
                    Projectile.width - 8, Projectile.height - 8, DustID.Torch, 0f, 0f, 100);
                    d.scale *= 2f + Main.rand.Next(6) * 0.1f;
                    d.velocity *= 0.2f;
                    d.noGravity = true;

                    Dust d2 = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default, 0.5f);
                    d2.fadeIn = 1f + Main.rand.Next(3) * 0.1f;
                    d2.velocity *= 0.05f;
                }
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
            Projectile.Kill();
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 v = new Vector2(0, 0);
                v = v.RotatedBy(MathHelper.PiOver4);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, 513, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            for (int i = 0; i < 5; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                d.velocity *= 1.4f;
            }
            for (int j = 0; j < 5; j++)
            {
                Dust d2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 13, 0f, 0f, 0, default, 2f);
                d2.noGravity = true;
                d2.velocity *= 3f;
            }
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
        }
    }
}