namespace BulletExpress.AmmoPro.Bullet
{
    public class RubberBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;
            Projectile.penetrate = 6;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;

            if (Projectile.velocity.Y > 12f)
            {
                Projectile.velocity.Y = 12f;
            }
            if (Projectile.velocity.X > 12f)
            {
                Projectile.velocity.X = 12f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 1)
            {
                Projectile.Kill();
            }
            else
            {
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.velocity = (target.Center - Projectile.Center) * 1f;

            for (int j = 0; j < 2; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Feather>(), 0f, 0f, 55, default, 0.5f);
            }

            if (Projectile.soundDelay == 0)
            {
                SoundStyle Sound = new SoundStyle($"{nameof(BulletExpress)}/IDB/Ogg/rubber_duck")
                {
                    Volume = 1.2f,
                    PitchVariance = 0.4f,
                };
                SoundEngine.PlaySound(Sound);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.velocity = (target.Center - Projectile.Center) * 1f;

            for (int j = 0; j < 2; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Feather>(), 0f, 0f, 55, default, 0.5f);
            }

            if (Projectile.soundDelay == 0)
            {   
                SoundStyle Sound = new SoundStyle($"{nameof(BulletExpress)}/IDB/Ogg/rubber_duck")
                {
                    Volume = 1.2f,
                    PitchVariance = 0.4f,
                };
                SoundEngine.PlaySound(Sound);
            }

            Projectile.damage = (int)(Projectile.damage * 0.8f);
        }
    }
}