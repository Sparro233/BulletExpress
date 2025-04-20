namespace BulletExpress.IDA.NPCs
{
	public class MushroomSlime : ModNPC
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
            NPC.lifeMax = 85;
            NPC.defense = 5;
            NPC.damage = 60;
            NPC.knockBackResist = 0.33f;

            NPC.width = 32;
            NPC.height = 26;
            NPC.scale = 1.2f;

            NPC.aiStyle = 1;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
            NPC.npcSlots = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.value = Item.buyPrice(0, 32, 2, 10);
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] { BuffID.Poisoned }
            };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneGlowshroom)
                return 0.08f;
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> 
            {
                new FlavorTextBestiaryInfoElement
                ("Mushroom slime lives permanently in fungal communities and, as a symbiotic relationship, spreads spores to anything it touches\n蘑菇史莱姆永久生活在真菌群落中，作为一种共生关系，将孢子传播到它所接触的任何东西上")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.rand.Next() == 0)
                npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 3, 4));
            npcLoot.Add(ItemDropRule.Common(2673, 5, 1));
        }
    }
}