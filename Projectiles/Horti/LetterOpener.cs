namespace BulletExpress.Projectiles.Horti
{
    public class LetterOpener : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 55;
            Projectile.width = 12;
            Projectile.height = 12;
            DrawOffsetX = -6;

            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.02f;

            Projectile.ai[0]++;
            if (Projectile.ai[0] > 20f)
            {
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.3f;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {            
            target.AddBuff(ModContent.BuffType<IDA.Buffs.Flog.FlogI>(), 120);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }
        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}