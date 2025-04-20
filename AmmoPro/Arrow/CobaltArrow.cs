namespace BulletExpress.AmmoPro.Arrow
{
    public class CobaltArrow : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 200;
            Projectile.extraUpdates = 1;
            Projectile.penetrate = 6; 
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.arrow = true;
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
                Projectile.ai[0] = 30f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
            }
            if (Projectile.timeLeft % 30 == 0)
            {
                Projectile.penetrate -= 1;
                Vector2 v = Projectile.velocity;
                Projectile split = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, -v, ModContent.ProjectileType<CobaltArrowI>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 1);
                Projectile.damage = (int)(Projectile.damage * 0.8f);
            }
            if (Main.rand.NextBool(10))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 55, default, 1.2f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 0, default, 2f);
        }
    }
}