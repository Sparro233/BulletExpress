namespace BulletExpress.IDA.Buffs
{
	public class AutumnLeave : ModBuff
    {
        public const int DefenseReductionPercent = 100;
        public static float DefenseMultiplier = 1 - DefenseReductionPercent / 100f;
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense *= DefenseMultiplier;
            player.GetModPlayer<ZifPlayer>().AutumnLeave = true;
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true; 
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ZifNpc>().AutumnLeave = true;
        }
    }
}