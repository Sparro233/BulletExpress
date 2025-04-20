namespace BulletExpress.AmmoPro.Arrow
{
    public class MapleLeaveArrow : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 200;
            Projectile.penetrate = 3;
            Projectile.localNPCHitCooldown = 20;

            Projectile.arrow = true;
            Projectile.usesLocalNPCImmunity = true;
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
            if (Main.rand.NextBool(40))
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-2, -2));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<Projectiles.Ranged.MapleLeave>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            if (Projectile.timeLeft % 20 == 0)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.MapleLeave>(), 0f, 0f, 55, default, 2f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Vector2 v = new Vector2(Main.rand.NextFloat(-6, 6), Main.rand.NextFloat(-12, -12));
            Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v, ModContent.ProjectileType<Projectiles.Ranged.MapleLeave>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 1);
            Projectile.penetrate--;
            if (Projectile.penetrate <= 1)
            {
                Projectile.Kill();
            }
            else
            {
                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            SoundEngine.PlaySound(SoundID.Grass, Projectile.position);
            return false;
        }
    }
}