namespace BulletExpress.IDA.NPCs
{
	public class StakesFishLight : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.lifeMax = 750;
            NPC.defense = 10;
            NPC.damage = 100;
            NPC.knockBackResist = 0.45f;

            NPC.width = 32;
            NPC.height = 24;
            NPC.scale = 1f;

            NPC.boss = true;
            //对岩浆免疫
            NPC.lavaImmune = true;
            /*不受重力影响。一般BOSS都是无重力的
            NPC.noGravity = true;*/

            NPC.aiStyle = 8;
            AIType = NPCID.HallowBoss;
            NPC.npcSlots = 5;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            NPC.value = Item.buyPrice(0, 0, 68, 5);
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[] { BuffID.Poisoned }
            };
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.bloodMoon)
            {
                return 0.005f;
            }
            return 0f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange
            (
                new IBestiaryInfoElement[] 
                {
                    BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                    new FlavorTextBestiaryInfoElement("尖桩鱼机缘巧合的吃掉了坠星，现在它拥有至高无上的智慧和魔力。……大概。"),
                }
            );
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.rand.Next(100) == 100)
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IDB.Potions.LiquidLightPotion>(), 2, 2, 5));
            npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<IDB.Potions.SuperLiquidLightPotion>()));
        }
    }
}
