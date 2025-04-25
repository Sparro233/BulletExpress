namespace BulletExpress.IDB.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class StormWing : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.defense = 2;
            Item.rare = 8;
            Item.value = Item.sellPrice(0, 6, 0, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }
         
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //免疫坠落
            player.noFallDmg = true;
            //召唤上限
            player.maxMinions += 1;
            base.UpdateAccessory(player, hideVisual);
            if (hideVisual)
            {
                player.wingTimeMax = 600;
            }
            else 
            {
                player.wingTimeMax = 600;
            }
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            //爬升加速度
            constantAscend = 1f;
            //最大爬升
            maxAscentMultiplier = 1.5f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            //水平加速度
            speed = 10f;
            //最大速度
            acceleration = 2.5f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.StormBar>(), 12)
            .AddIngredient(575, 20)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}
        


 