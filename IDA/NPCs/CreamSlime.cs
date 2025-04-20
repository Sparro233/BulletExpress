namespace BulletExpress.IDA.NPCs
{
	public class CreamSlime : ModNPC
    {
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
            NPC.lifeMax = 115;
            NPC.defense = 5;
            NPC.damage = 25;
            NPC.knockBackResist = 0.77f;

            NPC.width = 32;
            NPC.height = 26;
            NPC.scale = 1.6f;

            NPC.aiStyle = 1;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
            NPC.npcSlots = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.value = Item.buyPrice(0, 0, 88, 88);
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] { BuffID.Poisoned }
            };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode)
            {
                return 0.02f;
            }
            return 0.01f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry Entry)
        {
            Entry.Info.AddRange(new List<IBestiaryInfoElement>
            {
                new FlavorTextBestiaryInfoElement
                ("Creamy slime is made entirely of food, but it's not clear who the food is\n奶油粘液完全由食物制成，但目前尚不清楚食物是谁")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.rand.Next() == 0)
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IDB.Potions.Food.SlimeMilk>(), 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.MilkCarton, 3, 2, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.Milkshake, 3, 2, 2));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IDB.Materials.SlimeCream>(), 3, 1, 3));
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Armors.奶油史莱姆的红蜡烛>(), 20, 1, 1));
        }
    }
}