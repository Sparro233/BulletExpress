namespace BulletExpress.IDB.Accessories
{
    public class StormHalo : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.rare = 8;
            Item.value = 30000;

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }
         
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //生命上限
            player.statLifeMax2 += 80;
            //魔力上限
            player.statManaMax2 += 80;
            //召唤上限
            player.maxMinions += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.StormBar>(), 3)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}
        


 