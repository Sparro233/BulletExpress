namespace BulletExpress.IDA.Tiles
{
    public class ChlorophyllCourier : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSand[Type] = true;
            TileID.Sets.Falling[Type] = true;
            TileID.Sets.FallingBlockProjectile[Type] = new TileID.Sets.FallingBlockProjectileInfo(ModContent.ProjectileType<Projectiles.Throwing.ChlorophyllProtocol>(), 50); // Tells which falling projectile to spawn when the tile should fall.
            TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
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
            Main.tileCut[Type] = false;
            Main.tileBlockLight[Type] = false;
            
            MineResist = 2f;
            MinPick = 35;
            DustType = 7;
            AddMapEntry(new Color(180, 120, 10));
        }
    }
}