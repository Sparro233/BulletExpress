namespace BulletExpress.IDA.Tiles
{
    public class AshesCourier : ModTile
    {
        //以下是物块格式！
        //沙子独有（沙瓦，污染，沙鲨，铲子，坠落，窒息，射弹，未知，通用放置，坠落合并）
        //基础属性
        //多格，实体，瓷砖？，侧放火把，顶部，平台，光标，桌子，桌子功能
        //害怕液体，害怕岩浆，融合土块，融合砖块，遮挡阳光，是地牢砖，是蜘蛛网，表面发光，是否矿物，勘探药水，勘探荧光，矿物优先
        //闪烁速度，能否闪烁，武器破坏，挖掘次数，镐力，碎片，颜色

        public override void SetStaticDefaults()
        {
            Main.tileSand[Type] = true;
            //TileID.Sets.Conversion.Sand[Type] = true; // Allows Clentaminator solutions to convert this tile to their respective Sand tiles.
            //TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true; // Allows Sandshark enemies to "swim" in this sand.
            //TileID.Sets.CanBeDugByShovel[Type] = true;
            TileID.Sets.Falling[Type] = true;
            //TileID.Sets.Suffocate[Type] = true;
            TileID.Sets.FallingBlockProjectile[Type] = new TileID.Sets.FallingBlockProjectileInfo(ModContent.ProjectileType<Projectiles.Throwing.AshesProtocol>(), 10); // Tells which falling projectile to spawn when the tile should fall.
            TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
            //TileID.Sets.GeneralPlacementTiles[Type] = false;
            TileID.Sets.ChecksForMerge[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
            TileObjectData.addTile(Type);

            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileBrick[Type] = false;
            Main.tileNoAttach[Type] = false;
            Main.tileSolidTop[Type] = false;
            TileID.Sets.Platforms[Type] = false;
            TileID.Sets.DisableSmartCursor[Type] = false;
            Main.tileTable[Type] = false;
            TileObjectData.newTile.UsesCustomCanPlace = false;

            Main.tileWaterDeath[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileStone[Type] = false;
            Main.tileNoSunLight[Type] = true;
            //Main.tileDungeom[Type]
            Main.tileCut[Type] = false;
            Main.tileBlockLight[Type] = false;
            //TileID.Sets.Ore[Type] = false;
            //Main.tileSpelunker[Type] = false;
            //Main.tileShine2[Type] = false;
            //Main.tileOreFinderPriority[Type] = 100;

            //Main.tileShine[Type] = 0;
            //Main.tileLighted[Type] = false;
            //Main.tileSolidTop[Type]
            MineResist = 2f;
            MinPick = 35;
            DustType = 7;
            AddMapEntry(new Color(180, 120, 10));

            //AdjTiles = new int[] { TileID.GlassKiln };
        }
    }
}