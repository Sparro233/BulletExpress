namespace BulletExpress.IDB.Materials
{
    public class ManganeseBar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;
            Item.value = Item.sellPrice(0, 0, 2, 0);

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 25;

            Item.autoReuse = true;

            Item.consumable = true;
            Item.createTile =
            ModContent.TileType<IDA.Tiles.ManganeseBar>();
            Item.placeStyle = 0;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<ManganeseOre>(), 2)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}