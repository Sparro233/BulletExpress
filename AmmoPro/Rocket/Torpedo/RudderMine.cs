namespace BulletExpress.AmmoPro.Rocket.Torpedo
{
    public class RudderMine : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //�ڲ��ƶ��͡���װ��ʱ��������˺���
            //ProjectileID.Sets.IsAMineThatDealsTripleDamageWhenStationary[Type] = true;

            //���ϵ���Ѿ�Ϊ���Ǵ�����һЩ���飺
            //�� PVP ���� NPC �������ײʱ���� timeLeft ����Ϊ 3 �͵��跽���Ա�ըҩ������������
            //ըҩҲ��� Shimmer �Ķ����������ڽӴ� Shimmer �ĵײ������ʱ������������ɱ�ը�˺������� For the Worthy �����е������������˺���
            ProjectileID.Sets.Explosive[Type] = true;
            //�������ɵ��˺���ԭ���в������Ѷȶ��仯��
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 10;
            Projectile.height = 10;
            DrawOffsetX = -6;
            DrawOriginOffsetY = -6;

            Projectile.timeLeft = 1800;
            Projectile.penetrate = 1;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X * 0.1f; //���ݵ��׵��ƶ�������ת���ס�

            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }

            Projectile.velocity.Y += 0.2f; //���������������ס���� Y Ϊ���С�
            Projectile.velocity *= 0.97f; //������������

            int index = Projectile.FindTargetWithLineOfSight(160);//�е��˵�ʱ��׷��ȥ
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f;
                Projectile.timeLeft = 60;
            }

            //��� timeLeft Ϊ <= 3�����������ס�
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.PrepareBombToBlow();
            }
            else
            {
                //�������û���ƶ��򼸺�û���ƶ�����ʹ�伸�����ɼ���
                if (Projectile.velocity.X > -0.2f && Projectile.velocity.X < 0.2f && Projectile.velocity.Y > -0.2f && Projectile.velocity.Y < 0.2f)
                {
                    Projectile.alpha += 2;
                    if (Projectile.alpha > 200)
                    {
                        Projectile.alpha = 200;
                    }
                }
                //����ʹ�䲻͸��������һ���̳���
                else
                {
                    Projectile.alpha = 0;
                    Dust newdust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, 0f, 0f, 55, default, 1f);
                    newdust.velocity *= 0f;
                }
            }

            //������ƶ��÷ǳ���������������ȫֹͣ��
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
            //�Ӵ�ש�ϵ�����
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = oldVelocity.X * -0.4f;
            }

            if (Projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 0.7f)
            {
                Projectile.velocity.Y = oldVelocity.Y * -0.4f;
            }
            //���� false����������Ͳ��ᱻɱ���������ȷʵϣ������䵯�ڽӴ�ͼ��ʱ��ը���벻Ҫ�ڴ˴����� true��
            //������� true�����䵯���ڲ�������С��������������ޱ�ը�뾶����
            //�෴������ Example Rocket Projectile һ������ 'Projectile.timeLeft = 3;'��
            return false;
        }

        public override void PrepareBombToBlow()
        {
            Projectile.tileCollide = false; //�����Ҫ���������������б���ϱ�ը����ը�ͻ��ڴ���ĵط���
            Projectile.alpha = 255; //ʹ���ײ��ɼ���
            //�����������ײ���С����Ӧ��ը�� ���뾶����
            //��� I��128����� III��200������˻����250
            //����ֵ������Ϊ��λ����� 128 / 16 = 8 ��ͼ�顣
            Projectile.Resize(128, 128);
            //���ñ�ը�Ļ��ˡ�
            //��� I��8f����� III��10f������˻����12f
            Projectile.knockBack = 8f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, 0f, 0f, 100, default, 3f);
                d.noGravity = true;
                d.velocity *= 4f;
            }
        }

        public override void OnKill(int timeLeft)
        {
            //���ű�ը����
            //SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            //�ٴε����䵯�Ĵ�С���Ա���м����ɱ�ը���ҳ���Ѫ�ȡ�
            //��� I��22����� III��80������˵������50
            Projectile.Resize(80, 80);

            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<RTBoom>(), Projectile.damage * 6, Projectile.knockBack = 0, Projectile.owner);
            
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, 0f, 0f, 200, default, 4f);
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);
        }
    }
}