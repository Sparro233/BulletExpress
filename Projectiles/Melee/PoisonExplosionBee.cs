namespace BulletExpress.Projectiles.Melee
{
    public class PoisonExplosionBee : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        public override void SetStaticDefaults()
        {
            //Éäµ¯¶¯»­Ò³Êý
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 34;
            Projectile.height = 34;

            Projectile.timeLeft = 240;
            Projectile.penetrate = 1;

            Projectile.friendly = true;   
            
            /*ProjectileID.Sets.MinionSacrificable[Type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Type] = true;*/
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();

            Projectile.ai[0] += 1f;
            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            if (Projectile.timeLeft % 5 == 0)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 44, 0f, 0f, 55, default, 1.8f);
                d.velocity.X *= 0f;
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

            float speed = 8f;

            Vector2 finalVelocity = (new Vector2(projDestinationX, projDestinationY) - Projectile.Center).SafeNormalize(-Vector2.UnitY) * speed;
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, finalVelocity, 1f / 12f);
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<PoisonExplosion>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            SoundEngine.PlaySound(SoundID.NPCHit9, Projectile.position);
        }
    }
}
