namespace BulletExpress.AmmoPro.CandyCorn
{
    public class BoomCandyCorn : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.scale = 0.6f;

            Projectile.timeLeft = 400;
            Projectile.extraUpdates = 1;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.05f;
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
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-8, 8), Main.rand.NextFloat(8, -8));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.CandyCorn, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            for (int j = 0; j < 12; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3.5f);
                d.noGravity = true;
                d.velocity *= 4f;
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-8, 8), Main.rand.NextFloat(8, -8));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.CandyCorn, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            for (int j = 0; j < 12; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3.5f);
                d.noGravity = true;
                d.velocity *= 4f;
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}