namespace BulletExpress.IDA.NPCs
{
	public class CrystalSlime : ModNPC
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
            NPC.lifeMax = 280;
            NPC.defense = 0;
            NPC.damage = 120;
            NPC.knockBackResist = 0.22f;

            NPC.width = 32;
            NPC.height = 28;
            NPC.scale = 1.2f;

            AIType = NPCID.QueenSlimeMinionBlue;

            NPC.aiStyle = 1;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
            NPC.npcSlots = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.value = Item.buyPrice(0, 1, 60, 10);
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] { BuffID.Poisoned }
            };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode && !Main.dayTime)
            {
                return 0.04f;
            }
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> 
            {
                new FlavorTextBestiaryInfoElement
                ("Crystal Slyme ate a lot of crystal fragments, which would shoot out in a dangerous way in case of danger\n水晶史莱姆吃掉了很多水晶碎片，遇到危险时会以危险的方式射出")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.rand.Next() == 0)
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 8, 1, 2));
            npcLoot.Add(ItemDropRule.Common(4988, 10, 1));
            npcLoot.Add(ItemDropRule.Common(502, 1, 1, 2));
        }
    }
}