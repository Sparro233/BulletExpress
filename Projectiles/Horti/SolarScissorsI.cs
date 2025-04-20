namespace BulletExpress.Projectiles.Horti
{
    public class SolarScissorsI : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.width = 42;
            Projectile.height = 42;

            Projectile.timeLeft = 600;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        public void FadeInAndOut()
        {
            if (Projectile.ai[0] <= 50f)
            {
                Projectile.alpha -= 25;
                if (Projectile.alpha < 100)
                    Projectile.alpha = 100;

                return;
            }

            Projectile.alpha += 25;
            if (Projectile.alpha > 255)
                Projectile.alpha = 255;
        }

        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X * 0.02f;

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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 v = Main.rand.NextVector2CircularEdge(400f, 400f);
            Vector2 I = v.SafeNormalize(Vector2.UnitY) * 12f;
            Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - I * 20f, I, ProjectileType<NuclearReactorFurnace>(), Projectile.damage / 2, 0f, Projectile.owner, 0f, target.Center.Y);

            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            v = v.RotatedBy(MathHelper.PiOver4);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<Ranged.DaylightExplodes>(), Projectile.damage / 2, Projectile.knockBack = 0, Projectile.owner);

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}