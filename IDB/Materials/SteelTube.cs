namespace BulletExpress.IDB.Materials
{
    public class SteelTube : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 0, 40);

            Item.ResearchUnlockCount = 25;
            Item.maxStack = 9999;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(3)
            .AddRecipeGroup("AnyBar")
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}