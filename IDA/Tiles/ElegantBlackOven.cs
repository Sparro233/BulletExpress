namespace BulletExpress.IDA.Tiles
{
    public class ElegantBlackOven : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.UsesCustomCanPlace = true;//是否使用自定义放置
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16 , 16 };
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.addTile(Type);

            Main.tileFrameImportant[Type] = true;//是否集成瓦片
            Main.tileTable[Type] = true;//是否桌子
            Main.tileSolidTop[Type] = true;//是否可载人航天

            Main.tileNoAttach[Type] = true;//禁用物块锚点
            TileID.Sets.DisableSmartCursor[Type] = true;//是否禁用智能光标

            Main.tileLavaDeath[Type] = true;//是否会被熔岩破坏

            AddMapEntry(new Color(55, 55, 55));

            DustType = 84;//破碎尘埃

            MineResist = 0.5f;//耐久度
            MinPick = 35;//硬度
        }
    } 
}
