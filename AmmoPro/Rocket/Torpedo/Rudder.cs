namespace BulletExpress.AmmoPro.Rocket.Torpedo
{
    public class Rudder : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 24;
            Projectile.height = 24;

            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.1f;

            Projectile.velocity.Y *= 0.99f;
            Projectile.velocity.Y += 0.8f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<RTBoom>(), Projectile.damage * 3, Projectile.knockBack = 0, Projectile.owner);
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<RTBoom>(), Projectile.damage * 3, Projectile.knockBack = 0, Projectile.owner);
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, 0f, 0f, 200, default, 4f);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

        }
    }
}