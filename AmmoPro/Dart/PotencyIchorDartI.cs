namespace BulletExpress.AmmoPro.Dart
{
    public class PotencyIchorDartI : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 400;          
            Projectile.extraUpdates = 1;

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
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, ProjectileID.GoldenShowerFriendly, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Vector2 v = new Vector2(Main.rand.NextFloat(-8, 8), Main.rand.NextFloat(8, -8));
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.GoldenShowerFriendly, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 v = new Vector2(Main.rand.NextFloat(-8, 8), Main.rand.NextFloat(8, -8));
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.GoldenShowerFriendly, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
        }
    }
}