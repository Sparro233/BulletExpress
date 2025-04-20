namespace BulletExpress.IDB.Materials
{
    public class Flour : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 1, 80);

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 5;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(32)
            .AddIngredient(ModContent.ItemType<WheatEar>())
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}