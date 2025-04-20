namespace BulletExpress.IDA.NPCs
{
	public class YoungBudSlime : ModNPC
    {
		public int StolenItems = 0;

		public override void SetStaticDefaults() 
        {
			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BlueSlime];

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() 
			{
				Velocity = 1f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}
		
        public override void SetDefaults()
        {
            NPC.lifeMax = 30;
            NPC.defense = 0;
            NPC.damage = 10;
            NPC.knockBackResist = 1f;

            NPC.width = 32;
            NPC.height = 28;
            NPC.scale = 1.2f;
            
            NPC.aiStyle = 1;
			AIType = NPCID.BlueSlime;
			AnimationType = NPCID.BlueSlime;
            NPC.npcSlots = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.value = Item.buyPrice(0, 0, 2, 0);
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] { BuffID.Poisoned }
            };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.dayTime)
            {
                return 0.06f;
            }
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> 
            {
                new FlavorTextBestiaryInfoElement
                ("Young bud slime with lots of seeds, Would drive out non plant life")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.rand.Next() == 0)
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 8, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.DaybloomSeeds, 2, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.MoonglowSeeds, 2, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.DeathweedSeeds, 2, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.WaterleafSeeds, 2, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IDB.Materials.WheatSeed>(), 2, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IDB.Materials.StrayCottonSeed>(), 2, 2, 4));
        }
    }
}