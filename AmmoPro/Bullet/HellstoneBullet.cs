namespace BulletExpress.AmmoPro.Bullet
{
	public class HellstoneBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.light = 0.4f;

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
            Vector2 V = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, V, ModContent.ProjectileType<Projectiles.Ranged.DaylightExplodes>(), Projectile.damage / 3, Projectile.knockBack, Projectile.owner);

            Vector2 v = Projectile.velocity;
            Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
            v2 *= 1f - Main.rand.NextFloat(0.2f);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v2, 400, Projectile.damage / 3, Projectile.knockBack, Projectile.owner);

            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 6, 0f, 0f, 55, default, 1f);
            d.velocity *= 5f;

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(24, 300);
            Vector2 V = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, V, ModContent.ProjectileType<Projectiles.Ranged.DaylightExplodes>(), Projectile.damage / 3, Projectile.knockBack = 0, Projectile.owner);

            Vector2 v = Projectile.velocity;
            Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
            v2 *= 1f - Main.rand.NextFloat(0.2f);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v2, 400, Projectile.damage / 3, Projectile.knockBack, Projectile.owner);

            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 6, 0f, 0f, 55, default, 1f);
            d.velocity *= 5f;

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 V = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, V, ModContent.ProjectileType<Projectiles.Ranged.DaylightExplodes>(), Projectile.damage / 3, Projectile.knockBack = 0, Projectile.owner);

            Vector2 v = Projectile.velocity;
            Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
            v2 *= 1f - Main.rand.NextFloat(0.2f);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v2, 400, Projectile.damage / 3, Projectile.knockBack, Projectile.owner);

            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 6, 0f, 0f, 55, default, 1f);
            d.velocity *= 5f;

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}