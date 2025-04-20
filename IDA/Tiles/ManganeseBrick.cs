namespace BulletExpress.IDA.Tiles
{
    public class ManganeseBrick : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.UsesCustomCanPlace = true;//是否使用自定义放置
            Main.tileFrameImportant[Type] = true;//是否集成瓦片
            Main.tileSolid[Type] = true;//是否固体

            TileID.Sets.DisableSmartCursor[Type] = true;//是否禁用智能光标

            Main.tileMergeDirt[Type] = true;//接壤土块
            Main.tileStone[Type] = true;//接壤砖块

            AddMapEntry(new Color(180, 120, 10));//颜色及大地图描述

            Main.tileBlockLight[Type] = true;//是否遮阳
            DustType = 84;//破碎尘埃

            MineResist = 1f;//耐久度
            MinPick = 35;//硬度
            HitSound = SoundID.Tink;
        }
    }
}