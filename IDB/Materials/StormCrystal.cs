namespace BulletExpress.IDB.Materials
{
    public class StormCrystal : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = 6;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 100;

            Item.autoReuse = true;

            Item.consumable = true;
            Item.createTile =
            ModContent.TileType<IDA.Tiles.StormCrystal>();
            Item.placeStyle = 0;

            Item.width = 16;
            Item.height = 16;
        }
    }
}