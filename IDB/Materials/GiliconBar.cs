namespace BulletExpress.IDB.Materials
{
	public class GiliconBar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 25;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 30, 0, 0);
            Item.rare = -1;

            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;

            Item.autoReuse = true;

            Item.consumable = true;
            Item.createTile =
            ModContent.TileType<IDA.Tiles.GiliconBar>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<EncapsulatedGilicon>(), 5)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}