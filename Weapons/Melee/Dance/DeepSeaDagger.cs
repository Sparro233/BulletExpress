namespace BulletExpress.Weapons.Melee.Dance
{
    public class DeepSeaDagger : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 60;
            Item.knockBack = 6;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.value = Item.sellPrice(1, 25, 0, 0);
            Item.rare = 8;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;
            Item.noMelee = false;
            Item.noUseGraphic = false;

            Item.scale = 1.2f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Dance.DeepSeaDagger>();
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                Item.useStyle = 1;
                Item.UseSound = SoundID.Item1;
                Item.knockBack = 6;
                Item.useTime = 16;
                Item.useAnimation = 16;

                Item.noMelee = false;
                Item.noUseGraphic = false;

                Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Dance.DeepSeaDagger>();
            }
            else
            {
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.UseSound = SoundID.Item84;
                Item.knockBack = 1f;
                Item.useTime = 36;
                Item.useAnimation = 36;

                Item.noMelee = true;
                Item.noUseGraphic = true;

                Item.shoot = ProjectileID.Typhoon;
            }
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                //右键时阻止默认射弹被使用
                type = 0;
            }
            else
            {
                //获取玩家和物品的近战比例。
                float adjustedItemScale = player.GetAdjustedItemScale(Item); 
                Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage * 3, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
                //在多人游戏中同步更改。
                NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); 
                //生成射弹
                return base.Shoot(player, source, position, velocity, type, damage, knockback);
            }
            return true;
        }
    }
}
