namespace BulletExpress.IDA.NPCs
{
	public class SiltSlime : ModNPC
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
            NPC.lifeMax = 10;
            NPC.defense = 255;
            NPC.damage = 10;
            NPC.knockBackResist = 0.44f;

            NPC.width = 32;
            NPC.height = 26;
            NPC.scale = 1.2f;

            NPC.aiStyle = 1;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
            NPC.npcSlots = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.value = Item.buyPrice(0, 0, 0, 1);
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] { BuffID.Poisoned }
            };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return 0.02f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> 
            {
                new FlavorTextBestiaryInfoElement
                ("This slime is covered in mud and serves as a very good defense\n这只史莱姆身上全是淤泥，起到了非常好的防御作用")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.rand.Next() == 0)
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 2, 2, 8));
            npcLoot.Add(ItemDropRule.Common(5438, 1, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IDB.Materials.StrayCottonSeed>(), 4, 1, 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IDB.Materials.WheatSeed>(), 4, 1, 5));
            npcLoot.Add(ItemDropRule.Common(176, 4, 1, 4));
        }
    }
}