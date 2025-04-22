namespace BulletExpress.IDB.Materials
{
    public class SlimeCream : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 10, 0);

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 5;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<RefinedSugarBottle>())
            .AddIngredient(ItemID.Gel)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}