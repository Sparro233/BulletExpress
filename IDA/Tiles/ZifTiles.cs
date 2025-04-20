namespace BulletExpress
{
    public class ManganeseOreSystem : ModSystem
    {
        public static LocalizedText ManganeseOreUnzip { get; private set; }
		//public static LocalizedText ObtainNaturalManganese { get; private set; }

        public override void SetStaticDefaults()
        {
            ManganeseOreUnzip = Mod.GetLocalization($"WorldGen.{nameof(ManganeseOreUnzip)}");
            //ObtainNaturalManganese = Mod.GetLocalization($"WorldGen.{nameof(ObtainNaturalManganese)}");
        }
        
        public void BlessWorldWithManganeseOre()
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                //�ⲻӦ�÷��������Է���һ
                return;
            }
        }/*
            //�����ⷢ������Ϸ�����У�������Ҫ����һ���߳������д˴��롣������ǲ�����������Ϸ���������ݵ��ӳ١��������Ҫ����ʱ��ִ�е������������������Ҫ��
            //�й���ϸ��Ϣ�������https��//github.com/tModLoader/tModLoader/wiki/World-Generation/#long-running-tasks��
            ThreadPool.QueueUserWorkItem(_ =>
            {
                //�㲥��Ϣ֪ͨ�û���
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(BlessedWithManganeseOreMessage.Value, 50, 255, 130);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(BlessedWithManganeseOreMessage.ToNetworkText(), new Color(50, 255, 130));
                }
                //100 �����ж��ٿ�ʯ�ߵ�����������У��������С���š���Ϊ�Ƚϣ�ǰ3�μ�̳�����飬��Լ275��190��120���ߵ�ĸ���Ӳģ��ʯ��������
                int splotches = (int)(500 * (Main.maxTilesX / 4200f));
                int highestY = (int)Utils.Lerp(Main.rockLayer, Main.UnderworldLayer, 0.5);
                for (int iteration = 0; iteration < splotches; iteration++)
                {
                    //����ʯ����°벿���ҵ�һ���㣬���ڵ������֮�ϡ�
                    int i = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                    int j = WorldGen.genRand.Next(highestY, Main.UnderworldLayer);

                    //OreRunner���ڰߵ�������ManganeseOre��OnKillֻ�ڷ�����������Ϸ�����У��������World Generation�����ǰ�ȫ�ġ�
                    WorldGen.OreRunner(i, j, WorldGen.genRand.Next(5, 9), WorldGen.genRand.Next(5, 9), (ushort)ModContent.TileType<ManganeseOre>());
                }
            });
        }*/

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int unfold = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

            if (unfold != -1)
            {
                tasks.Insert(unfold + 1, new ManganeseOrePass("���ڸ���Ԫ�����ڱ�", 237.4298f));
            }
        }
    }

    public class ManganeseOrePass : GenPass
    {
        public ManganeseOrePass(string name, float loadWeight) : base(name, loadWeight)
        {

        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            //progress.message���������´���ʱ��ʾ���û�����Ϣ��
            //���Ű������Ϣ˵�������������΢����һ�㣬��Ҫȷ���������㹻�������ԣ��Ա���й����ų���
            progress.Message = ManganeseOreSystem.ManganeseOreUnzip.Value;
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, Main.maxTilesY);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 8), ModContent.TileType<IDA.Tiles.ManganeseOre>());
            }
            //Ores�ǳ��򵥣�����ֻ��ʹ��forѭ����WorldGen.TileRunner�������з���ָ����Ƭ�İߵ㡣
            //�� 6E-05 ���ǡ���ѧ����������ֻ�Ǳ�ʾ0.00006������ĳЩ����������Ķ���
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                //��forѭ�����ڲ���Ӧ�����ǿ�ʯ�ĵ����ߵ㡣
                //���ȣ�����ͨ��ѡ�������X��yֵ�����ѡ�������ϵ��κ����ꡣ
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                //worldgen.worldSurfaceLowʵ��������ߵı�����Ƭ��ʵ���ϣ���������Ҫʹ��worldgen.rocklayer������worldgenֵ��
                int y = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, Main.maxTilesY);
                //Ȼ�����ǵ��þ��������ǿ�ȡ����������������worldgen.tilerunner���Լ�����ϣ�����õ���Ƭ��
                //���������Ⳣ�������Ͳ������Բ鿴�������ɵ���״��
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(6, 8), WorldGen.genRand.Next(8, 10), ModContent.TileType<IDA.Tiles.ManganeseOre>());
            }
            //���ߣ����ǿ��Լ�����Ǹ���Ȥ���������Ѿ����ڵ�ͼ�顣
            //�����������°�װworldgen.tilerunner��ʹ��ʯ����ѩ�����ɡ�
            /*Tile tile = Framing.GetTileSafely(x, y);
            if (tile.HasTile && tile.TileType == TileID.SnowBlock)
            {
                WorldGen.TileRunner();
            }*/
        }
    }
}