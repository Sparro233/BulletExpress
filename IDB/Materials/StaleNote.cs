namespace BulletExpress.IDB.Materials
{
    public class StaleNote : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;

            // 原版Boss召唤前提（多人模式）
            // NPCID.Sets.MPAllowedEnemies[NPCID.Plantera] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item3;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = 8000;
            Item.rare = 1;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 3;

            Item.consumable = true;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.BossSpawners;
        }

        public override bool CanUseItem(Player player)
        {
            // 如果存在以下Boss会无法召唤
            //return !NPC.AnyNPCs(ModContent.NPCType<NPCs.远古幻灵.远古幻灵>());
            return true;
        }

        public override bool? UseItem(Player player)
        {
            //在多人模式下首先寻找召唤者
            if (player.whoAmI == Main.myPlayer)
            {
                //音效
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                int type = 370;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                }
                /*else
                {
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
                }*/
            }
            return true;
        }
    }
}