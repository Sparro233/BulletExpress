namespace BulletExpress.IDB.Materials
{
    public class DirtPlatform : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 200;

            Item.autoReuse = true;

            Item.consumable = true;
            Item.createTile =
            ModContent.TileType<IDA.Tiles.DirtPlatform>();
            Item.placeStyle = 0;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(2)
            .AddRecipeGroup("AnyDirtBlock")
            .Register();
        }
    }
}