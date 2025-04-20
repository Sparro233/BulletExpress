namespace BulletExpress.Projectiles.Melee
{
    public class HandheldKillerBee : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Spear); 

            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 58;
            Projectile.height = 58;

            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = 10;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        //���� Spear Projectile �ķ�Χ����Щ�ǿ���д�����ԣ��Է����봴��һ���̳���������Ե��ࡣ
        protected virtual float HoldoutRangeMin => 30f;
        protected virtual float HoldoutRangeMax => 100f;

        public override bool PreAI()
        {
            //�������Ǿ����������������ʵ�������Ϊ�˴���һ�������ֲ�����������
            Player player = Main.player[Projectile.owner]; 
            //�����䵯��֡�д��ڵĳ���ʱ��
            int duration = player.itemAnimationMax;
            //��������ֳֵ��䵯 ID
            player.heldProj = Projectile.whoAmI;

            //���б�Ҫ������ʣ����䵯ʱ��
            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
            }

            //Velocity ����� spear ʵ����û��ʹ�ã�������ʹ�� field ���洢 spear �Ĺ�������
            Projectile.velocity = Vector2.Normalize(Projectile.velocity);

            //����ì���˶��ڼ�
            float half = duration * 0.5f;
            float progress;

            //progress = �ڼ䣬half = ����ڼ䣬duration = �����ڼ䡣
            if (Projectile.timeLeft < half)
            {
                progress = Projectile.timeLeft / half;
            }
            else
            {
                progress = (duration - Projectile.timeLeft) / half;
            }

            //���䵯�� HoldoutRangeMin = ��Сά�ַ�Χ �ƶ��� HoldoutRangeMax = ���ά�ַ�Χ ���ƻأ�ʹ�� SmoothStep = ƽ������ �������ƶ�
            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

            //�� �䵯 Ӧ���ʵ�����ת��
            if (Projectile.spriteDirection == -1)
            {
                //��� �䵯 ��������ת 45 ��
                Projectile.rotation += MathHelper.ToRadians(35f);
            }
            else
            {
                //��� �䵯 ���ң�����ת 135 ��
                Projectile.rotation += MathHelper.ToRadians(145f);
            }
            if (!Main.dedServ)
            {
                if (Main.rand.NextBool(3))
                {
                    Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Projectile.velocity.X * 2f, Projectile.velocity.Y * 2f, Alpha: 128, Scale: 1.2f);
                }
                if (Main.rand.NextBool(4))
                {
                    Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Alpha: 128, Scale: 0.3f);
                }
            }
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(4, -4)); 
                
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<PoisonExplosionBee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
        }
    }
}