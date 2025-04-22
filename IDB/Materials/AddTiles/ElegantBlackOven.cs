namespace BulletExpress.IDB.Materials.AddTiles
{
    public class ElegantBlackOven : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 0, 5, 0);

            Item.DefaultToPlaceableTile(ModContent.TileType<IDA.Tiles.ElegantBlackOven>());
            Item.placeStyle = 0;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ManganeseBatteries>(), 4)
            .AddRecipeGroup("AnyIronBar", 8)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}