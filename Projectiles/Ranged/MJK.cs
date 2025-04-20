namespace BulletExpress.Projectiles.Ranged
{
    public class MJK : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.scale = 1.2f;
            DrawOriginOffsetY = 0;
            DrawOffsetX = 0;

            Projectile.timeLeft = 360;
            Projectile.penetrate = 1;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            Projectile.rotation += Projectile.velocity.X * 0.025f; // ���ݵ��׵��ƶ�������ת���ס�

            Projectile.velocity.Y += 0.2f; // ���������������ס���� Y Ϊ���С�
            Projectile.velocity *= 0.97f; // ������������

            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }

            Projectile.ai[0] += 1f;
            if (Main.mouseRight)
            {
                int index2 = Projectile.FindTargetWithLineOfSight(320);// �е��˵�ʱ��׷��ȥ
                if (index2 >= 0)
                {
                    NPC npc = Main.npc[index2];
                    Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f;
                    Projectile.timeLeft = 60;
                }

                Projectile.ai[0] += 1f;
                if (Projectile.ai[0] >= 20f)
                {
                    Projectile.ai[0] = 20f;
                    Projectile.timeLeft -= 60;
                }
            }
            
            int index = Projectile.FindTargetWithLineOfSight(160);// �е��˵�ʱ��׷��ȥ
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f;
                Projectile.timeLeft = 60;
            }

            // ��� timeLeft Ϊ <= 3�����������ס�
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.PrepareBombToBlow();
            }
            else
            {
                // �������û���ƶ��򼸺�û���ƶ�����ʹ�伸�����ɼ���
                if (Projectile.velocity.X > -0.2f && Projectile.velocity.X < 0.2f && Projectile.velocity.Y > -0.2f && Projectile.velocity.Y < 0.2f)
                {
                    Projectile.alpha += 2;
                    if (Projectile.alpha > 200)
                    {
                        Projectile.alpha = 200;
                    }
                }
                // ����ʹ�䲻͸����
                else
                {
                    Projectile.alpha = 0;
                }
            }

            // ������ƶ��÷ǳ���������������ȫֹͣ��
            if (Projectile.velocity.X > -0.1f && Projectile.velocity.X < 0.1f)
            {
                Projectile.velocity.X = 0f;
            }

            if (Projectile.velocity.Y > -0.1f && Projectile.velocity.Y < 0.1f)
            {
                Projectile.velocity.Y = 0f;
            }

            if (Main.mouseRight)
            {
                Vector2 unit = Vector2.Normalize(Main.MouseWorld - player.Center);
                float rotaion = unit.ToRotation();
                player.itemTime = 10;
                player.itemAnimation = 10;
                player.direction = Main.MouseWorld.X < player.Center.X ? -1 : 1;
                player.itemRotation = (float)Math.Atan2(rotaion.ToRotationVector2().Y * player.direction, rotaion.ToRotationVector2().X * player.direction);
                Vector2 unit2 = Vector2.Normalize(Main.MouseWorld - Projectile.Center);

                if (Vector2.Distance(Projectile.Center, Main.MouseWorld) < 28)
                {
                    Projectile.velocity *= 0.5f;
                    Projectile.rotation += 0.25f;
                    Projectile.Center = Main.MouseWorld;
                }
                else
                {
                    Projectile.velocity = unit2 * 28;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // �Ӵ�ש�ϵ�����
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = oldVelocity.X * -0.4f;
            }

            if (Projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 0.7f)
            {
                Projectile.velocity.Y = oldVelocity.Y * -0.4f;
            }
            // ���� false����������Ͳ��ᱻɱ���������ȷʵϣ������䵯�ڽӴ�ͼ��ʱ��ը���벻Ҫ�ڴ˴����� true��
            // ������� true�����䵯���ڲ�������С��������������ޱ�ը�뾶����
            // �෴������ Example Rocket Projectile һ������ 'Projectile.timeLeft = 3;'��
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<AmmoPro.Rocket.Torpedo.RTBoom>(), Projectile.damage * 3, Projectile.knockBack, Projectile.owner);

            for (int i = 0; i < 3; i++)
            {
                Vector2 VI = new Vector2(Main.rand.NextFloat(-10, 10), Main.rand.NextFloat(10, -10));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, VI, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.CookieResidue>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            }

            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, 0f, 0f, 200, default, 4f);

            SoundEngine.PlaySound(SoundID.Item89, Projectile.position);
        }
    }
}