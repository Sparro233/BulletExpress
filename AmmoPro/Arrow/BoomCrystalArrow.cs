namespace BulletExpress.AmmoPro.Arrow
{
    public class BoomCrystalArrow : ModProjectile
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
                Projectile.velocity.Y += 0.2f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //这是一种灵活的方式是分裂子射弹
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.5f);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, 522, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }

            //这是以一种固定的方式分裂子射弹
            /*Vector2 v = new Vector2(18, 0);
            for (int i = 0; i < 3; i++)
            {
                v = v.RotatedBy(MathHelper.PiOver4);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.CandyCorn, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }*/

            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.5f);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, 522, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);
            Projectile.Kill();
        }
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
                v2 *= 1f - Main.rand.NextFloat(0.5f);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, -v2, 522, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);
        }
    }
}