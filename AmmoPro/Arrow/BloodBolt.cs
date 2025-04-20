namespace BulletExpress.AmmoPro.Arrow
{
    public class BloodBolt : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 600;

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
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 125, 0f, 0f, 55, default, 1f);
            d.velocity *= 0f;
            d.noGravity = true;
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
            target.AddBuff(69, 300);
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(69, 600);
        }
    }
}