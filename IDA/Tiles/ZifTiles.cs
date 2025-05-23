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
                //这不应该发生，但以防万一
                return;
            }
        }/*
            //由于这发生在游戏过程中，我们需要在另一个线程上运行此代码。如果我们不这样做，游戏将经历短暂的延迟。这对于需要更长时间执行的世界生成任务尤其必要。
            //有关详细信息，请参阅https：//github.com/tModLoader/tModLoader/wiki/World-Generation/#long-running-tasks。
            ThreadPool.QueueUserWorkItem(_ =>
            {
                //广播消息通知用户。
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText(BlessedWithManganeseOreMessage.Value, 50, 255, 130);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    ChatHelper.BroadcastChatMessage(BlessedWithManganeseOreMessage.ToNetworkText(), new Color(50, 255, 130));
                }
                //100 控制有多少矿石斑点产生到世界中，按世界大小缩放。作为比较，前3次祭坛被粉碎，大约275、190或120个斑点的各自硬模矿石被产生。
                int splotches = (int)(500 * (Main.maxTilesX / 4200f));
                int highestY = (int)Utils.Lerp(Main.rockLayer, Main.UnderworldLayer, 0.5);
                for (int iteration = 0; iteration < splotches; iteration++)
                {
                    //在岩石层的下半部分找到一个点，但在地下深度之上。
                    int i = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                    int j = WorldGen.genRand.Next(highestY, Main.UnderworldLayer);

                    //OreRunner将在斑点中生成ManganeseOre。OnKill只在服务器或单人游戏上运行，因此运行World Generation代码是安全的。
                    WorldGen.OreRunner(i, j, WorldGen.genRand.Next(5, 9), WorldGen.genRand.Next(5, 9), (ushort)ModContent.TileType<ManganeseOre>());
                }
            });
        }*/

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int unfold = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

            if (unfold != -1)
            {
                tasks.Insert(unfold + 1, new ManganeseOrePass("正在富饶元素周期表", 237.4298f));
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
            //progress.message是运行以下代码时显示给用户的消息。
            //试着把你的信息说清楚。您可以稍微聪明一点，但要确保它具有足够的描述性，以便进行故障排除。
            progress.Message = ManganeseOreSystem.ManganeseOreUnzip.Value;
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                int y = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, Main.maxTilesY);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(6, 8), ModContent.TileType<IDA.Tiles.ManganeseOre>());
            }
            //Ores非常简单，我们只需使用for循环和WorldGen.TileRunner在世界中放置指定瓦片的斑点。
            //“ 6E-05 ”是“科学记数法”它只是表示0.00006，但在某些方面更容易阅读。
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                //此for循环的内部对应于我们矿石的单个斑点。
                //首先，我们通过选择随机的X和y值来随机选择世界上的任何坐标。
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                //worldgen.worldSurfaceLow实际上是最高的表面瓦片。实际上，您可能需要使用worldgen.rocklayer或其他worldgen值。
                int y = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, Main.maxTilesY);
                //然后，我们调用具有随机“强度”和随机“步数”的worldgen.tilerunner，以及我们希望放置的瓦片。
                //您可以随意尝试力量和步伐，以查看它们生成的形状。
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(6, 8), WorldGen.genRand.Next(8, 10), ModContent.TileType<IDA.Tiles.ManganeseOre>());
            }
            //或者，我们可以检查我们感兴趣的坐标中已经存在的图块。
            //在以下条件下包装worldgen.tilerunner将使矿石仅在雪中生成。
            /*Tile tile = Framing.GetTileSafely(x, y);
            if (tile.HasTile && tile.TileType == TileID.SnowBlock)
            {
                WorldGen.TileRunner();
            }*/
        }
    }
}