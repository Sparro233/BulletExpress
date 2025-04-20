namespace BulletExpress.IDA.Tiles
{
    public class StormCrystal : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.UsesCustomCanPlace = true;//是否使用自定义放置
            Main.tileFrameImportant[Type] = false;//是否集成瓦片
            Main.tileTable[Type] = false;//是否可放置蜡烛
            Main.tileSolidTop[Type] = false;//是否可载人航天
            Main.tileSolid[Type] = true;//是否固体

            Main.tileNoAttach[Type] = false;//禁用物块锚点
            TileObjectData.newTile.StyleHorizontal = false;//依赖物块锚点
            TileID.Sets.DisableSmartCursor[Type] = true;//是否禁用智能光标
            TileID.Sets.Platforms[Type] = false;//是否属于平台

            Main.tileWaterDeath[Type] = false;//是否会被水流破坏
            Main.tileLavaDeath[Type] = false;//是否会被熔岩破坏
            Main.tileCut[Type] = false;//是否会被武器破坏

            Main.tileMergeDirt[Type] = true;//接壤土块
            Main.tileStone[Type] = true;//接壤砖块

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(200, 200, 200), name);
            //TileObjectData.addTile(Type);

            Main.tileBlockLight[Type] = true;//是否遮阳
            Main.tileShine2[Type] = false;//物块发光
            Main.tileLighted[Type] = true;//是否闪烁
            Main.tileShine[Type] = 520;//闪烁速度
            DustType = 84;//破碎尘埃

            TileID.Sets.Ore[Type] = true;//是否属于矿石
            Main.tileSpelunker[Type] = true;//是否能被侦查
            Main.tileOreFinderPriority[Type] = 690;//稀有度
            MineResist = 5f;//耐久度
            MinPick = 200;//硬度
            HitSound = SoundID.Tink;
        }
    }
}           