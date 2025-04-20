namespace BulletExpress.IDA.Tiles
{
    public enum PlantStage : byte
    {
        Planted,
        Growing,
        Grown
    }

    public class Wheat : ModTile
    {
        //用于可读性和踢出界的常量
        private const int FrameWidth = 18;

        public override void SetStaticDefaults()
        {
            //是否集成瓦片
            Main.tileFrameImportant[Type] = true;
            //种植箱平铺效果
            Main.tileNoFail[Type] = true;
            //是否会被熔岩破坏
            Main.tileLavaDeath[Type] = true;
            //阻止黑曜石生成
            Main.tileObsidianKill[Type] = true;
            //是否会被武器破坏
            Main.tileCut[Type] = true;
            //可被种子替换
            TileID.Sets.ReplaceTileBreakUp[Type] = true;
            //不被当做宝物
            TileID.Sets.IgnoredInHouseScore[Type] = true;
            //被树苗忽略
            TileID.Sets.IgnoredByGrowingSaplings[Type] = true;
            //套用AI
            AdjTiles = new int[] { TileID.BloomingHerbs };
            //尘埃和尘埃类型
            HitSound = SoundID.Grass;
            DustType = DustID.Ambient_DarkBrown;
            //不要使用它，它会导致许多意外的副作用，例如开花时变成闪耀根
            //Main.tileAlch[Type] = true;
            //名字和颜色
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(128, 128, 128), name);
            //可种植的位置
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
                TileID.Grass,
                TileID.HallowedGrass,
            };
            TileObjectData.newTile.AnchorAlternateTiles = new int[]
            {
                TileID.ClayPot,
                TileID.PlanterBox,
                ModContent.TileType<IDA.Tiles.DirtPlatform>()
            };
            TileObjectData.addTile(Type);
        }

        public override void MouseOver(int i, int j)
        {

            //一种植物有 3 个阶段，种植、生长和生长
            //遗憾的是，改造后的植物无法通过花靴种植
            //TODO草药的智能光标支持，请参见SmartCursorHelper.Step_AlchemySeeds
            //再生的TODO人员:
            //-Player.PlaceThing_Tiles_BlockPlacementForAssortedThings：检查Where Type==84（Grown Herb）
            //-Player.ItemCheck_GetTileCutigNoreList：也许可以泛化？
            //TODO香草种子代替完全生长的药草

            // A plant with 3 stages, planted, growing and grown
            // Sadly, modded plants are unable to be grown by the flower boots
            //TODO smart cursor support for herbs, see SmartCursorHelper.Step_AlchemySeeds
            //TODO Staff of Regrowth:
            //- Player.PlaceThing_Tiles_BlockPlacementForAssortedThings: check where type == 84 (grown herb)
            //- Player.ItemCheck_GetTileCutIgnoreList: maybe generalize?
            //TODO vanilla seeds to replace fully grown herb
        }

        public override bool CanPlace(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            //获取Tile实例的安全方法

            if (tile.HasTile)
            {
                int tileType = tile.TileType;
                if (tileType == Type)
                {
                    PlantStage stage = GetStage(i, j); 
                    //草药的当前阶段
                
                    return stage == PlantStage.Grown;
                    //如果已经生长，则只能再次放置在同一药草上
                }
                else
                {
                    //支持香草/草本植物：
                    if (Main.tileCut[tileType] || TileID.Sets.BreakableWhenPlacing[tileType] || tileType == TileID.WaterDrip || tileType == TileID.LavaDrip || tileType == TileID.HoneyDrip || tileType == TileID.SandDrip)
                    {
                        bool foliageGrass = tileType == TileID.Plants || tileType == TileID.Plants2;
                        bool moddedFoliage = tileType >= TileID.Count && (Main.tileCut[tileType] || TileID.Sets.BreakableWhenPlacing[tileType]);
                        bool harvestableVanillaHerb = Main.tileAlch[tileType] && WorldGen.IsHarvestableHerbWithSeed(tileType, tile.TileFrameX / 18);

                        if (foliageGrass || moddedFoliage || harvestableVanillaHerb)
                        {
                            WorldGen.KillTile(i, j);
                            if (!tile.HasTile && Main.netMode == NetmodeID.MultiplayerClient)
                            {
                                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
                            }
                            return true;
                        }
                    }

                    return false;
                }
            }

            return true;
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 0)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            //对于使用StyleAlch的图块，这是-1，但对于Herbs，Vanilla设置为-2，这会导致放置预览和放置的图块之间出现轻微的视觉偏移。
            offsetY = -2;
        }

        public override bool CanDrop(int i, int j)
        {
            PlantStage stage = GetStage(i, j);

            if (stage == PlantStage.Planted)
            {
                //刚种植时不要掉落任何东西
                return false;
            }
            return true;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            PlantStage stage = GetStage(i, j);

            Vector2 worldPosition = new Vector2(i, j).ToWorldCoordinates();
            Player nearestPlayer = Main.player[Player.FindClosest(worldPosition, 16, 16)];

            int herbItemType = ModContent.ItemType<IDB.Materials.WheatEar>();
            int herbItemStack = 1;

            int seedItemType = ModContent.ItemType<IDB.Materials.WheatSeed>();
            int seedItemStack = 1;

            if (stage == PlantStage.Growing)
            {
                //成熟
                herbItemStack = 1;
            }
            if (stage == PlantStage.Grown)
            {
                //开花
                herbItemStack = Main.rand.Next(1, 3);
                seedItemStack = Main.rand.Next(1, 6);
                /*herbItemStack = 1;
                seedItemStack = Main.rand.Next(1, 4);*/
            }
            /*if (stage == PlantStage.Grown && nearestPlayer.active && (nearestPlayer.HeldItem.type == ItemID.StaffofRegrowth || nearestPlayer.HeldItem.type == ItemID.AcornAxe))
            {
                //通过再生员工提高产量
                herbItemStack = Main.rand.Next(1, 3);
                seedItemStack = Main.rand.Next(1, 6);
            }*/

            if (herbItemType > 0 && herbItemStack > 0)
            {
                yield return new Item(herbItemType, herbItemStack);
            }

            if (seedItemType > 0 && seedItemStack > 0)
            {
                yield return new Item(seedItemType, seedItemStack);
            }
        }

        public override bool IsTileSpelunkable(int i, int j)
        {
            PlantStage stage = GetStage(i, j);

            //只有当药草生长时才会发光
            return stage == PlantStage.Grown;
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            PlantStage stage = GetStage(i, j);

            //如果存在下一阶段，则仅增长到下一阶段。我们不希望我们的瓷砖变成粉红色！
            if (stage != PlantStage.Grown)
            {
                //增加X帧以更改舞台
                tile.TileFrameX += FrameWidth;

                //如果在多人游戏中，同步帧更改
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.SendTileSquare(-1, i, j, 1);
                }
            }
        }

        //快速获取药草当前阶段的辅助方法（假设坐标处的瓦片是我们的药草）
        private static PlantStage GetStage(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            return (PlantStage)(tile.TileFrameX / FrameWidth);
        }
    }
}