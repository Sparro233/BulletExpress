namespace BulletExpress.IDA.Tiles
{
    public class TangerineCoconut : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 16 };
            TileObjectData.addTile(Type);

            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = false;
            Main.tileSolidTop[Type] = true;
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

            HitSound = SoundID.Dig;
            DustType = DustID.Stone;
            MineResist = 2f;
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
            Vector2.Zero, ModContent.ProjectileType<Projectiles.Ranged.Coconut>(), 100, 10f);
        }

    }
}