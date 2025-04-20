namespace BulletExpress.IDA.Tiles
{
    public class ManganeseBar : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            Main.tileFrameImportant[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileSolidTop[Type] = true;
            Main.tileSolid[Type] = true;

            TileObjectData.newTile.StyleHorizontal = true;
            TileID.Sets.DisableSmartCursor[Type] = true;

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(200, 200, 200), name);
            TileObjectData.addTile(Type);

            Main.tileLighted[Type] = true;
            Main.tileShine[Type] = 520;
            DustType = 84;

            Main.tileOreFinderPriority[Type] = 0;//稀有度
            MineResist = 0.5f;//耐久度
            MinPick = 35;//硬度
        }
    }
}