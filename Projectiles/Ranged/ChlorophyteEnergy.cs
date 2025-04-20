namespace BulletExpress.Projectiles.Ranged
{
    public class ChlorophyteEnergy : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 155;
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.timeLeft = 600;

            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.1f;

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

            Vector2 v = (new Vector2(projDestinationX, projDestinationY) - Projectile.Center).SafeNormalize(-Vector2.UnitY) * speed;
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, v, 1f / 12f);
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<CEBoom>()/*ProjectileID.DD2ExplosiveTrapT3Explosion*/, Projectile.damage, Projectile.knockBack, Projectile.owner);
            for (int j = 0; j < 10; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 131, 0f, 0f, 100, default, 1f);
                d.noGravity = true;
                d.velocity *= 8f;
                Dust d2= Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 131, 0f, 0f, 100, default, 0.5f);
                d2.velocity *= 6f;
            }
            SoundEngine.PlaySound(SoundID.Item66, Projectile.position);
        }
    }
}