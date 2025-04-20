namespace BulletExpress.Projectiles.Horti
{
    public class DrTear : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //¹¥»÷Ë®Ä¸´¥µç
            ProjectileID.Sets.AllowsContactDamageFromJellyfish[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.width = 30;
            Projectile.height = 30;

            Projectile.timeLeft = 90;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            float v = Projectile.velocity.ToRotation();
            Projectile.rotation = v + 3.92f;
            Player player = Main.player[Projectile.owner];
            Projectile.velocity *= 0.96f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Type].Value;
            var rot = Projectile.rotation + (float)Math.PI / 2f;
            Main.spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition, null, Color.White, rot,
                tex.Size() / 2f, Projectile.scale, 0, 0);
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<Horti.Slash>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);

            Player player = Main.player[Projectile.owner];
            player.Heal(5);
        }

        public override void OnKill(int timeLeft)
        {
            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 15, default, 1f);
                d.velocity *= 1f;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}