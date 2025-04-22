namespace BulletExpress.IDB.Materials
{
    public class ManganeseBatteries : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 2, 0);

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 25;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(9)
            .AddIngredient(ModContent.ItemType<ManganeseBar>())
            .AddRecipeGroup("AnyBar")
            .AddIngredient(ModContent.ItemType<Flour>())
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}
