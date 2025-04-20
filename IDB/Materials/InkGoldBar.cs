namespace BulletExpress.IDB.Materials
{
	public class InkGoldBar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;
            Item.value = 25000;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 25;

            ItemID.Sets.BossBag[Type] = true;
            Item.autoReuse = true;

            Item.consumable = true;
            Item.createTile =
            ModContent.TileType<IDA.Tiles.InkGoldBar>();
            Item.placeStyle = 0;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<LightPowder>(), 3)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}