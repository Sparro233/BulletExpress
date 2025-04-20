namespace BulletExpress.Weapons.Ranged.Ter
{
    public class Glacier : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item40;
            Item.damage = 50;
            Item.knockBack = 10;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.value = Item.sellPrice(0, 1, 20, 0);
            Item.rare = 3;
            //ȡ����Ʒ��ײ�˺�
            Item.noMelee = true;
            //ʹ�õ�ҩ��Ĭ�Ϸ��䣬����
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 12f;
            //��д�ᵼ����Ʒ��ǽ����ʱ��ǽ
            Item.width = 16;
            Item.height = 16;
        }

        public override void HoldItem(Player player)
        {
            //�ѻ���
            player.scope = true;
        }

        public override Vector2? HoldoutOffset()
        {
            //��������������ֲ�����ͼ�ν�λ��
            return new Vector2(-20f, 6f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            //����ê��
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<Projectiles.Ranged.Glacier>(), damage, knockback, player.whoAmI);
            //������䵯Ϊ�������Ϊ
            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<AmmoPro.Bullet.IceSnowBullet>();
            }
            //ѡ�����䵯
            int ammo = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
            //������䵯���Բ��㣬����
            if (Main.projectile[ammo].extraUpdates < 2)
            {
                Main.projectile[ammo].extraUpdates = 2;
            }
            if (Main.projectile[ammo].penetrate <= 2 && Main.projectile[ammo].penetrate != -1)
            {
                Main.projectile[ammo].penetrate = 2;
                Main.projectile[ammo].localNPCHitCooldown = 20;
                Main.projectile[ammo].usesLocalNPCImmunity = true;
            }
            //�����Ϲ�����ѡ��Ŀ��Ϊ���λ�ã�player���λ�ã�goalĿ��λ��
            Vector2 goal = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceiling = goal.Y;
            //ceiling = �컨��
            if (ceiling > player.Center.Y + 200f)
            {
                ceiling = player.Center.Y + 200f;
            }
            for (int i = 0; i < 3; i++)
            {
                //position = λ�� - (���Ҿ���) * ���λ��
                position = player.Center - new Vector2(Main.rand.NextFloat(100) * player.direction, 600f);
                //����ÿ���䵯���ɵ�ľ���
                position.Y -= 100 * i;
                //����
                Vector2 direction = goal - position;
                if (direction.Y < 0f)
                {
                    direction.Y *= -1f;
                }
                //����ɢ������Խ��Խ������׼
                if (direction.Y < 10f)
                {
                    direction.Y = 10f;
                }
                direction.Normalize();
                direction *= velocity.Length();
                //(�䵯���з���,Խ��Խ������׼)�����շ����ٶ�
                direction.Y += Main.rand.Next(-20, 20) * 0.02f;
                //�������ɵ��䵯
                Projectile.NewProjectile(source, position, direction, 118, damage, knockback, player.whoAmI, 0f, ceiling);
            }

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(724)
            .AddIngredient(5070, 10)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}