namespace BulletExpress.AmmoPro.Arrow
{
    public class GooSFeather : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 15;
            Projectile.width = 10;
            Projectile.height = 10;
            DrawOffsetX = -10;
            DrawOriginOffsetY = -10;

            Projectile.timeLeft = 180;
            Projectile.penetrate = 6;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.03f;
            Projectile.velocity.Y *= 0.99f;
            Projectile.velocity.Y += 0.1f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y += 0.1f;
            }
            int index = Projectile.FindTargetWithLineOfSight(400);
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity += (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 1.1f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            if (Projectile.soundDelay == 0)
            {
                SoundStyle Sound = new SoundStyle($"{nameof(BulletExpress)}/IDB/Ogg/enemyimpact1")
                {
                    Volume = 0.5f,
                    PitchVariance = 0.2f,
                };
                SoundEngine.PlaySound(Sound);
            }
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Feather>(), 0f, 0f, 55, default, 2f);
            d.noGravity = true;
        }

        public override void OnKill(int timeLeft)
        {
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Feather>(), 0f, 0f, 55, default, 2f);
            d.noGravity = true;
        }
    }
}