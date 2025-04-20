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
            //取消物品碰撞伤害
            Item.noMelee = true;
            //使用弹药，默认发射，射速
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 12f;
            //不写会导致物品贴墙掉落时穿墙
            Item.width = 16;
            Item.height = 16;
        }

        public override void HoldItem(Player player)
        {
            //狙击镜
            player.scope = true;
        }

        public override Vector2? HoldoutOffset()
        {
            //修正武器与玩家手部的贴图衔接位置
            return new Vector2(-20f, 6f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            //武器锚点
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<Projectiles.Ranged.Glacier>(), damage, knockback, player.whoAmI);
            //如果主射弹为，则更改为
            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<AmmoPro.Bullet.IceSnowBullet>();
            }
            //选中主射弹
            int ammo = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
            //如果主射弹属性不足，则补足
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
            //从天上攻击，选中目标为鼠标位置，player玩家位置，goal目标位置
            Vector2 goal = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceiling = goal.Y;
            //ceiling = 天花板
            if (ceiling > player.Center.Y + 200f)
            {
                ceiling = player.Center.Y + 200f;
            }
            for (int i = 0; i < 3; i++)
            {
                //position = 位置 - (左右距离) * 随机位置
                position = player.Center - new Vector2(Main.rand.NextFloat(100) * player.direction, 600f);
                //增加每个射弹生成点的距离
                position.Y -= 100 * i;
                //反向
                Vector2 direction = goal - position;
                if (direction.Y < 0f)
                {
                    direction.Y *= -1f;
                }
                //增加散布，数越大越难以瞄准
                if (direction.Y < 10f)
                {
                    direction.Y = 10f;
                }
                direction.Normalize();
                direction *= velocity.Length();
                //(射弹飞行方向,越大越难以瞄准)，最终飞行速度
                direction.Y += Main.rand.Next(-20, 20) * 0.02f;
                //最终生成的射弹
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