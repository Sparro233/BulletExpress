namespace BulletExpress.IDA.Tiles
{
    public class DesertGeneratingDevice : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSand[Type] = true;
            TileID.Sets.Falling[Type] = true;
            //Tells which falling projectile to spawn when the tile should fall.
            TileID.Sets.FallingBlockProjectile[Type] = new TileID.Sets.FallingBlockProjectileInfo(ModContent.ProjectileType<Projectiles.Ranged.ArtificialDesert>(), 100); 
            TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
            TileID.Sets.ChecksForMerge[Type] = true;

            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
            TileObjectData.newTile.CoordinatePadding = 2;
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
        public override bool Slope(int i, int j)
        {
            return false;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            //伤害，击退等你可以随意调整
            Projectile.NewProjectile(new EntitySource_TileBreak(i, j), new Vector2(i + 1, j + 1) * 16,
            Vector2.Zero, ModContent.ProjectileType<Projectiles.Ranged.ArtificialDesert>(), 200, 20f);
        }
    }
}