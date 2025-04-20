namespace BulletExpress.IDA.Tiles
{
    public class InkCopperBar : ModTile
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

            AddMapEntry(new Color(200, 200, 200), Language.GetText("MetalBar"));
            TileObjectData.addTile(Type);

            Main.tileLighted[Type] = true;
            Main.tileShine[Type] = 520;
            DustType = 84;

            MineResist = 0.5f;
            MinPick = 35;
        }
    }
}