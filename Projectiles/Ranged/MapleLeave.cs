namespace BulletExpress.Projectiles.Ranged
{
    public class MapleLeave : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 10;
            Projectile.height = 10;
            DrawOffsetX = -6;
            DrawOriginOffsetY = -6;

            Projectile.timeLeft = 200;
            Projectile.penetrate = 2;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X * 0.1f;
            Projectile.velocity *= 0.97f;
            Projectile.velocity.Y += 0.2f;
            if (Projectile.velocity.X > -0.1f && Projectile.velocity.X < 0.1f)
            {
                Projectile.velocity.X = 0f;
            }
            if (Projectile.velocity.Y > -0.1f && Projectile.velocity.Y < 0.1f)
            {
                Projectile.velocity.Y = 0f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                Projectile.velocity.X = oldVelocity.X * -0.7f;
            }
            if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                Projectile.velocity.Y = oldVelocity.Y * -0.7f;
            }
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(ModContent.BuffType<IDA.Buffs.AutumnLeave>(), 600);
            SoundEngine.PlaySound(SoundID.Grass, Projectile.position);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<IDA.Buffs.AutumnLeave>(), 600);
            SoundEngine.PlaySound(SoundID.Grass, Projectile.position);
            Projectile.damage = (int)(Projectile.damage * 0.5f);
        }

        public override void OnKill(int timeLeft)
        {
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.MapleLeave>(), 0f, 0f, 55, default, 2f);
        }
    }
}