namespace BulletExpress.IDA.Tiles
{
    public class DirtPlatform : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.UsesCustomCanPlace = true;//�Ƿ�ʹ���Զ������
            Main.tileFrameImportant[Type] = false;//�Ƿ񼯳���Ƭ
            Main.tileTable[Type] = true;//�Ƿ�ɷ�������
            Main.tileSolidTop[Type] = true;//�Ƿ�����˺���
            Main.tileSolid[Type] = true;//�Ƿ����

            Main.tileNoAttach[Type] = false;//�������ê��
            TileObjectData.newTile.StyleHorizontal = false;//�������ê��
            TileID.Sets.DisableSmartCursor[Type] = false;//�Ƿ�������ܹ��
            TileID.Sets.Platforms[Type] = true;//�Ƿ�����ƽ̨

            Main.tileWaterDeath[Type] = false;//�Ƿ�ᱻˮ���ƻ�
            Main.tileLavaDeath[Type] = false;//�Ƿ�ᱻ�����ƻ�
            Main.tileCut[Type] = false;//�Ƿ�ᱻ�����ƻ�

            Main.tileMergeDirt[Type] = true;//��������
            Main.tileStone[Type] = true;//����ש��

            Main.tileBlockLight[Type] = true;
            DustType = 2;
                        
            MineResist = 0.5f;
            MinPick = 35;
            AddMapEntry(new Color(180, 120, 10));
        }
    }
}