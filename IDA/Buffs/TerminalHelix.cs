namespace BulletExpress.IDA.Buffs
{
	public class TerminalHelix : ModBuff
    {
        public const int DefenseReductionPercent = 10000;
        public static float DefenseMultiplier = 1 + DefenseReductionPercent / 100f;

        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.rand.NextBool(3))
            {
                Dust d = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<IDA.Powders.Light>());
                d.velocity *= 0.1f;
            }
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.statLifeMax2 = 100;
            player.statDefense *= DefenseMultiplier;

            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;

            Main.pvpBuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.life = 100;
            npc.defense = 10000;
            //npc.lifeRegen -= npc.buffTime[buffIndex];
            if (Main.rand.NextBool(3))
            {
                Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, ModContent.DustType<IDA.Powders.Light>());
                d.velocity *= 0.1f;
            }
        }
    }
}