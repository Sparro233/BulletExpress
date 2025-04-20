namespace BulletExpress.IDA.NPCs
{
	public class StakesFishRampage : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.lifeMax = 5;
            NPC.defense = 5;
            NPC.damage = 40;
            NPC.knockBackResist = 0.6f;

            NPC.width = 40;
            NPC.height = 24;
            NPC.scale = 1f;

            AIType = NPCID.FlyingFish;

            NPC.aiStyle = 2;
            NPC.npcSlots = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.value = Item.buyPrice(0, 0, 3, 12);
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] { BuffID.Poisoned }
            };
        }

        public override void AI()
        {
            NPC.TargetClosest(true);
            NPC.rotation = NPC.velocity.ToRotation();

            Player player = Main.player[NPC.target];

            //这几乎总是 AI（） 中的第一个代码，因为它负责找到合适的玩家目标
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            if (player.dead)
            {
                //如果目标玩家已死亡，则逃跑
                NPC.velocity.Y -= 0.04f;
                //此方法使得当 Boss 处于“消失范围”（屏幕外）时，它会在 10 刻内消失
                NPC.EncourageDespawn(10);
                return;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.bloodMoon)
            {
                return 0.04f;
            }
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
				new FlavorTextBestiaryInfoElement(""),
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.rand.Next(100) == 100)
            npcLoot.Add(ItemDropRule.Common(4621, 1, 1, 2));
            npcLoot.Add(ItemDropRule.Common(362, 3, 2, 2));
        }
    }
}