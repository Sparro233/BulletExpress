namespace BulletExpress.Projectiles.Ranged
{
    public class LifeLight : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;

            Projectile.timeLeft = 400;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;

            if (Main.rand.NextBool(5))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Green>(), 0f, 0f, 55, default, 1f);
                d.velocity *= 0f;
                d.noGravity = true;
            }

            float projDestinationX = Projectile.position.X;
            float projDestinationY = Projectile.position.Y;
            float maxHomingDistance = 600f;
            bool isHoming = false;
            Projectile.ai[0]++;
            if (Projectile.ai[0] > 15f)
            {
                Projectile.ai[0] = 15f;

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC searchNPC = Main.npc[i];
                    if (searchNPC.CanBeChasedBy(this))
                    {
                        float targetPosX = searchNPC.position.X + (searchNPC.width / 2);
                        float targetPosY = searchNPC.position.Y + (searchNPC.height / 2);
                        float distanceFromProjToTarget = Math.Abs(Projectile.position.X + (Projectile.width / 2) - targetPosX) + Math.Abs(Projectile.position.Y + (Projectile.height / 2) - targetPosY);
                        
                        if (distanceFromProjToTarget < maxHomingDistance && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, searchNPC.position, searchNPC.width, searchNPC.height))
                        {
                            maxHomingDistance = distanceFromProjToTarget;
                            projDestinationX = targetPosX;
                            projDestinationY = targetPosY;
                            isHoming = true;
                        }
                    }
                }
            }
            if (!isHoming)
            {
                projDestinationX = Projectile.position.X + (Projectile.width / 2) + Projectile.velocity.X * 100f;
                projDestinationY = Projectile.position.Y + (Projectile.height / 2) + Projectile.velocity.Y * 100f;
            }

            float speed = 18f;

            Vector2 finalVelocity = (new Vector2(projDestinationX, projDestinationY) - Projectile.Center).SafeNormalize(-Vector2.UnitY) * speed;
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, finalVelocity, 1f / 12f);
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Player player = Main.player[Projectile.owner];
            player.Heal(1);
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];
            player.Heal(1);
        }
    }
}