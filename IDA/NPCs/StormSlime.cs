namespace BulletExpress.IDA.NPCs
{
    public class StormSlime : ModNPC
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
            NPC.lifeMax = 320;
            NPC.damage = 50;
            NPC.defense = 30;
            NPC.knockBackResist = 0.55f;

            NPC.width = 32;
            NPC.height = 24;
            NPC.scale = 1f;

            NPC.aiStyle = 1;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
            NPC.npcSlots = 1;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.value = Item.buyPrice(0, 5, 90, 90);
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] { BuffID.Poisoned }
            };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.hardMode && spawnInfo.Player.ZoneSkyHeight)
            {
                return 0.02f;
            }
            return 0f;
            if (Main.hardMode && Main.raining)
            {
                return 0.08f;
            }
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement>
            {
                new FlavorTextBestiaryInfoElement
                ("Born from the magic of the Storm Mine, the Tempest Slime has great tenacity and vitality that is difficult to kill\n从风暴矿的魔法中诞生的暴风雨史莱姆，拥有难以杀死的坚韧和生命力")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.rand.Next() == 0)
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 2));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IDB.Materials.StormCrystal>(), 2, 2, 5));
            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<IDB.Materials.StormCrystal>()));
        }
    }
}
