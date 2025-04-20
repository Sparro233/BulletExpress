namespace  BulletExpress.AmmoPro.Bullet
{
    public class MythrilBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.light = 0.2f;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 2;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            int index = Projectile.FindTargetWithLineOfSight(240);
            if (index >= 0)
            {
                if (Projectile.timeLeft % 15 == 0)
                {
                    Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<MythrilLight>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
                    Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightIII>(), 0f, 0f, 0, default, 1.2f);
                    d.velocity *= 3f;
                    d.noGravity = true;
                }
            }
            if (Main.rand.NextBool(5))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightIII>(), 0f, 0f, 55, default, 1f);
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

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.Kill();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            Projectile.Kill();
            return false;
        }
    }
}