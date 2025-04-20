namespace BulletExpress.IDB.Materials
{
	public class LightBar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.rare = 3;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 25;

            ItemID.Sets.BossBag[Type] = true;
            Item.autoReuse = true;

            Item.consumable = true;
            Item.createTile =
            ModContent.TileType<IDA.Tiles.LightBar>();
            Item.placeStyle = 0;

            Item.width = 16;
            Item.height = 16;
        }

		public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<LightCrystal>(), 3)
            .AddTile(TileID.Hellforge)
            .Register();
        }
    }
}