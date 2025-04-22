namespace BulletExpress.IDB.Materials
{
    public class StormBar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = 9;

            Item.ResearchUnlockCount = 25;
            Item.maxStack = 9999;

            Item.autoReuse = true;

            Item.consumable = true;
            Item.createTile =
            ModContent.TileType<IDA.Tiles.StormBar>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<StormCrystal>(), 4)
            .AddIngredient(ModContent.ItemType<MagicCrystal>())
            .AddIngredient(ModContent.ItemType<LightCrystal>())
            .AddTile(247)
            .Register();
        }
    }
}