namespace BulletExpress.IDA.Tiles
{
    public class DirtPlatform : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.UsesCustomCanPlace = true;//是否使用自定义放置
            Main.tileFrameImportant[Type] = false;//是否集成瓦片
            Main.tileTable[Type] = true;//是否可放置蜡烛
            Main.tileSolidTop[Type] = true;//是否可载人航天
            Main.tileSolid[Type] = true;//是否固体

            Main.tileNoAttach[Type] = false;//禁用物块锚点
            TileObjectData.newTile.StyleHorizontal = false;//依赖物块锚点
            TileID.Sets.DisableSmartCursor[Type] = false;//是否禁用智能光标
            TileID.Sets.Platforms[Type] = true;//是否属于平台

            Main.tileWaterDeath[Type] = false;//是否会被水流破坏
            Main.tileLavaDeath[Type] = false;//是否会被熔岩破坏
            Main.tileCut[Type] = false;//是否会被武器破坏

            Main.tileMergeDirt[Type] = true;//接壤土块
            Main.tileStone[Type] = true;//接壤砖块

            Main.tileBlockLight[Type] = true;
            DustType = 2;
                        
            MineResist = 0.5f;
            MinPick = 35;
            AddMapEntry(new Color(180, 120, 10));
        }
    }
}