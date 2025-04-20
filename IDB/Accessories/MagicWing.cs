namespace BulletExpress.IDB.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class MagicWing : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.rare = 4;
            Item.value = Item.sellPrice(0, 4, 0, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }
         
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noFallDmg = true;
            player.manaRegen += 2;
            base.UpdateAccessory(player, hideVisual);
            if (hideVisual)
            {
                player.wingTimeMax = 240;
            }
            else 
            {
                player.wingTimeMax = 240;
            }
        }
        
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            constantAscend = 0.1f;
            maxAscentMultiplier = 1.5f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 7f;
            acceleration = 1.5f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.MagicBar>(), 4)
            .AddIngredient(575, 20)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}
        


 