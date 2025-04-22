namespace BulletExpress.IDB.Materials
{
    public class WheatSeed : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetStaticDefaults()
        {
            //禁用自动放置掉落，似乎没什么用
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true; 
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 1, 0);
            
            Item.ResearchUnlockCount = 25;

            Item.DefaultToPlaceableTile(ModContent.TileType<IDA.Tiles.Wheat>());

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(9)
            .AddIngredient(ModContent.ItemType<WheatEar>())
            .Register();
        }
    }
}