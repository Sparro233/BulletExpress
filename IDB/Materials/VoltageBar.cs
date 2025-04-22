namespace BulletExpress.IDB.Materials
{
	public class VoltageBar : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;
            Item.value = Item.sellPrice(0, 2, 30, 30);
            Item.rare = 11;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 25;

            Item.autoReuse = true;

            Item.consumable = true;
            Item.createTile =
            ModContent.TileType<IDA.Tiles.VoltageBar>();
            Item.placeStyle = 0;
        }
    }
}