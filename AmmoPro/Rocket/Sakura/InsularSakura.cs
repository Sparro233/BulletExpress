namespace BulletExpress.AmmoPro.Rocket.Sakura
{
    public class InsularSakura : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Projectile.width = 18;
            Projectile.height = 18;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X * 0.1f;
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 2)
            {
                PrepareBombToBlow();
            }
            else
            {
                Projectile.localAI[1]++;
                if (Projectile.localAI[1] > 6f)
                {
                    Projectile.alpha = 0;
                }
                else
                {
                    Projectile.alpha = (int)(255f - 42f * Projectile.localAI[1]) + 100;
                    if (Projectile.alpha > 255)
                    {
                        Projectile.alpha = 255;
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    if (!(Projectile.localAI[1] > 9f))
                    {
                        continue;
                    }
                    float velocityXAdder = 0f;
                    float velocityYAdder = 0f;
                    if (i == 1)
                    {
                        velocityXAdder = Projectile.velocity.X * 0.5f;
                        velocityYAdder = Projectile.velocity.Y * 0.5f;
                    }
                    if (Main.rand.NextBool(2))
                    {
                        Dust d = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + velocityXAdder, Projectile.position.Y + 3f + velocityYAdder) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, ModContent.DustType<IDA.Powders.Powder>(), 0f, 0f, 100);
                        d.scale *= 1.4f + Main.rand.Next(10) * 0.1f;
                        d.velocity *= 0.2f;
                        d.noGravity = true;
                    }
                    if (Main.rand.NextBool(2))
                    {
                        Dust d2 = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + velocityXAdder, Projectile.position.Y + 3f + velocityYAdder) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default, 0.5f);
                        d2.fadeIn = 0.5f + Main.rand.Next(5) * 0.1f;
                        d2.velocity *= 0.05f;
                    }
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

                float speed = 9f;

                Vector2 v = (new Vector2(projDestinationX, projDestinationY) - Projectile.Center).SafeNormalize(-Vector2.UnitY) * speed;
                Projectile.velocity = Vector2.Lerp(Projectile.velocity, v, 1f / 12f);

                if (Projectile.velocity.X < 0f)
                {
                    Projectile.spriteDirection = -1;
                    Projectile.rotation = (float)Math.Atan2(0f - Projectile.velocity.Y, 0f - Projectile.velocity.X) - MathHelper.PiOver2;
                }
                else
                {
                    Projectile.spriteDirection = 1;
                    Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathHelper.PiOver2;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<SakuraBoom>(), Projectile.damage / 3, Projectile.knockBack = 0, Projectile.owner);
            for (int i = 0; i < 4; i++)
            {
                Vector2 v2 = new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-10, -8));
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v2, ModContent.ProjectileType<PinkCrystal>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 1);
            }
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.ShyPink>(), 0f, 0f, 0, default, 3f);
            d.velocity *= 4f;
            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<SakuraBoom>(), Projectile.damage / 3, Projectile.knockBack = 0, Projectile.owner);
            for (int i = 0; i < 4; i++)
            {
                Vector2 v2 = new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-10, -8));
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v2, ModContent.ProjectileType<PinkCrystal>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 1);
            }
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.ShyPink>(), 0f, 0f, 0, default, 3f);
            d.velocity *= 4f;

            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
        }
    }
}