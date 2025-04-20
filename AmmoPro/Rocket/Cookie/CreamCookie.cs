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
            //��� timeLeft Ϊ <= 3�������������
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 2)
            {
                PrepareBombToBlow();
            }
            else
            {
                Projectile.localAI[1]++;
                //6 �̺�ʹ�����ȫ��͸����
                if (Projectile.localAI[1] > 6f)
                {
                    //0 Alpha ����ȫ��͸���ġ�
                    Projectile.alpha = 0; 
                }
                else
                {
                    //�ڴ�֮ǰ��ÿ tick ��������
                    Projectile.alpha = (int)(255f - 42f * Projectile.localAI[1]) + 100;
                    if (Projectile.alpha > 255)
                    {
                        //255 Alpha ����ȫ͸���ġ�
                        Projectile.alpha = 255; 
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    //�� 9 �̹�ȥ֮ǰ��Ҫ��ʼ���ɳ�����
                    if (!(Projectile.localAI[1] > 9f))
                    {
                        continue;
                    }
                    //��������������Ϊ�ҳ����һЩ�˶���
                    float velocityXAdder = 0f;
                    float velocityYAdder = 0f;
                    if (i == 1)
                    {
                        velocityXAdder = Projectile.velocity.X * 0.5f;
                        velocityYAdder = Projectile.velocity.Y * 0.5f;
                    }
                    //����һЩ�𳾡�
                    if (Main.rand.NextBool(2))
                    {
                        Dust d = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + velocityXAdder, Projectile.position.Y + 3f + velocityYAdder) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, 15, 0f, 0f, 100);
                        d.scale *= 1.4f + Main.rand.Next(10) * 0.1f;
                        d.velocity *= 0.2f;
                        d.noGravity = true;
                        /*��Һ����ʹ�ã����ǻ�����Һ��ۼ������ǻ��档
                        if (d.type == Dust.dustWater())
                        {
                            d.scale *= 0.65f;
                            d.velocity += Projectile.velocity * 0.1f;
                        }*/
                    }

                    //����һЩ�̳���
                    if (Main.rand.NextBool(2))
                    {
                        Dust d = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + velocityXAdder, Projectile.position.Y + 3f + velocityYAdder) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default, 0.5f);
                        d.fadeIn = 0.5f + Main.rand.Next(5) * 0.1f;
                        d.velocity *= 0.05f;
                    }
                }   
                //���ȣ��������Ŀ�ĵ�����Ϊ�䵱ǰλ�á��⽫����һ���и��¡�
                float projDestinationX = Projectile.position.X;
                float projDestinationY = Projectile.position.Y;
                //���鳲���루������Ϊ��λ����ÿ��ͼ�� 16 ���أ���� 600 ���� = 37.5 ��ͼ�顣
                float maxHomingDistance = 600f; 
                bool isHoming = false;
                //��ʱ�������ڹ�λǰ�ȴ��೤ʱ�䡣
                Projectile.ai[0]++;
                //�ڹ�λ֮ǰ�ȴ�һС��ʱ�䡣�ڱ�����Ϊ 15 ����ʱ���ۡ�
                if (Projectile.ai[0] > 15f)
                {
                    Projectile.ai[0] = 15f;
                    //�������� NPC ���ҵ�Ŀ�ꡣ
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        NPC searchNPC = Main.npc[i];
                        //���Ŀ����Թ�λ����
                        if (searchNPC.CanBeChasedBy(this))
                        {
                            //��ȡĿ���λ�á�
                            float targetPosX = searchNPC.position.X + (searchNPC.width / 2);
                            float targetPosY = searchNPC.position.Y + (searchNPC.height / 2);
                            //�ҵ��ӵ��赽Ŀ��ľ��롣
                            float distanceFromProjToTarget = Math.Abs(Projectile.position.X + (Projectile.width / 2) - targetPosX) + Math.Abs(Projectile.position.Y + (Projectile.height / 2) - targetPosY);
                            //�������������Զ�Ѱ�ľ����ڣ����ҵ��������ߡ�
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
                //������û�й麽���뽫��Ŀ�ĵ�����Ϊ����ǰ����λ��֮ǰ��
                if (!isHoming)
                {
                    projDestinationX = Projectile.position.X + (Projectile.width / 2) + Projectile.velocity.X * 100f;
                    projDestinationY = Projectile.position.Y + (Projectile.height / 2) + Projectile.velocity.Y * 100f;
                }
                //���� 16f ��ֵ���ܻᵼ�»���޷�������顣
                //Ҫ��һ������ٶȣ����� SetDefaults���� ������ extraUpdates��
                float speed = 9f;
                //ǰ���������õ�λ�á�Ҫô��Ŀ���λ�ã�Ҫô�����Լ�ǰ�档
                Vector2 finalVelocity = (new Vector2(projDestinationX, projDestinationY) - Projectile.Center).SafeNormalize(-Vector2.UnitY) * speed;
                Projectile.velocity = Vector2.Lerp(Projectile.velocity, finalVelocity, 1f / 12f);
                //�ػ���ƶ��ķ�����ת����������־��鳯����ȷ�ķ���
                //������sprite �ϵ�����ʼ�����泯�ϡ�
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