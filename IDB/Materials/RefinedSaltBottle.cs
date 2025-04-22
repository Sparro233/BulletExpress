namespace BulletExpress.IDB.Materials
{
    public class RefinedSaltBottle : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;
            Item.value = Item.sellPrice(0, 0, 1, 0);

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 30;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddIngredient(ItemID.Fireblossom);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}