namespace BulletExpress.AmmoPro.Rocket.Cookie
{
    public class CreamCookie : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Explosive[Type] = true;
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            //如果 timeLeft 为 <= 3，则引爆火箭。
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 2)
            {
                PrepareBombToBlow();
            }
            else
            {
                Projectile.localAI[1]++;
                //6 刻后，使火箭完全不透明。
                if (Projectile.localAI[1] > 6f)
                {
                    //0 Alpha 是完全不透明的。
                    Projectile.alpha = 0; 
                }
                else
                {
                    //在此之前，每 tick 淡入火箭。
                    Projectile.alpha = (int)(255f - 42f * Projectile.localAI[1]) + 100;
                    if (Projectile.alpha > 255)
                    {
                        //255 Alpha 是完全透明的。
                        Projectile.alpha = 255; 
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    //在 9 刻过去之前不要开始生成尘埃。
                    if (!(Projectile.localAI[1] > 9f))
                    {
                        continue;
                    }
                    //这两个变量用于为灰尘添加一些运动。
                    float velocityXAdder = 0f;
                    float velocityYAdder = 0f;
                    if (i == 1)
                    {
                        velocityXAdder = Projectile.velocity.X * 0.5f;
                        velocityYAdder = Projectile.velocity.Y * 0.5f;
                    }
                    //生成一些火尘。
                    if (Main.rand.NextBool(2))
                    {
                        Dust d = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + velocityXAdder, Projectile.position.Y + 3f + velocityYAdder) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, 15, 0f, 0f, 100);
                        d.scale *= 1.4f + Main.rand.Next(10) * 0.1f;
                        d.velocity *= 0.2f;
                        d.noGravity = true;
                        /*由液体火箭使用，它们会留下液体痕迹而不是火焰。
                        if (d.type == Dust.dustWater())
                        {
                            d.scale *= 0.65f;
                            d.velocity += Projectile.velocity * 0.1f;
                        }*/
                    }

                    //生成一些烟尘。
                    if (Main.rand.NextBool(2))
                    {
                        Dust d = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + velocityXAdder, Projectile.position.Y + 3f + velocityYAdder) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default, 0.5f);
                        d.fadeIn = 0.5f + Main.rand.Next(5) * 0.1f;
                        d.velocity *= 0.05f;
                    }
                }   
                //首先，将火箭的目的地设置为其当前位置。这将在下一节中更新。
                float projDestinationX = Projectile.position.X;
                float projDestinationY = Projectile.position.Y;
                //最大归巢距离（以像素为单位）。每个图块 16 像素，因此 600 像素 = 37.5 个图块。
                float maxHomingDistance = 600f; 
                bool isHoming = false;
                //计时器，用于归位前等待多长时间。
                Projectile.ai[0]++;
                //在归位之前等待一小段时间。在本例中为 15 个即时报价。
                if (Projectile.ai[0] > 15f)
                {
                    Projectile.ai[0] = 15f;
                    //搜索所有 NPC 以找到目标。
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        NPC searchNPC = Main.npc[i];
                        //如果目标可以归位到。
                        if (searchNPC.CanBeChasedBy(this))
                        {
                            //获取目标的位置。
                            float targetPosX = searchNPC.position.X + (searchNPC.width / 2);
                            float targetPosY = searchNPC.position.Y + (searchNPC.height / 2);
                            //找到从弹丸到目标的距离。
                            float distanceFromProjToTarget = Math.Abs(Projectile.position.X + (Projectile.width / 2) - targetPosX) + Math.Abs(Projectile.position.Y + (Projectile.height / 2) - targetPosY);
                            //如果距离在最大自动寻的距离内，并且弹道有视线。
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
                //如果火箭没有归航，请将其目的地设置为它当前飞行位置之前。
                if (!isHoming)
                {
                    projDestinationX = Projectile.position.X + (Projectile.width / 2) + Projectile.velocity.X * 100f;
                    projDestinationY = Projectile.position.Y + (Projectile.height / 2) + Projectile.velocity.Y * 100f;
                }
                //高于 16f 的值可能会导致火箭无法穿过物块。
                //要进一步提高速度，请在 SetDefaults（） 中增加 extraUpdates。
                float speed = 9f;
                //前往上面设置的位置。要么是目标的位置，要么就在自己前面。
                Vector2 finalVelocity = (new Vector2(projDestinationX, projDestinationY) - Projectile.Center).SafeNormalize(-Vector2.UnitY) * speed;
                Projectile.velocity = Vector2.Lerp(Projectile.velocity, finalVelocity, 1f / 12f);
                //沿火箭移动的方向旋转火箭，并保持精灵朝向正确的方向。
                //这样，sprite 上的脸将始终正面朝上。
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
            Projectile.Kill();
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<CookieBoom>(), Projectile.damage / 2, Projectile.knockBack = 0, Projectile.owner);
            for (int i = 0; i < 4; i++)
            {
                Vector2 v2 = new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-10, -8));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v2, ModContent.ProjectileType<CookieResidue>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
            for (int j = 0; j < 2; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Cookie>(), 0f, 0f, 0, default, 3f);
                d.velocity *= 4f;
            }
            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
        }
    }
}