namespace BulletExpress.AmmoPro.Arrow
{
    public class EatersBiteArrow : ModProjectile
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
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //这是一种灵活的方式是分裂子射弹
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.8f);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, 307, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.8f);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, 307, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.8f);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, 307, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
        }
    }
}