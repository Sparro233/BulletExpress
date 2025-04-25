namespace BulletExpress.IDA.Buffs
{
	public class LeadPoisoning : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ZifPlayer>().LeadPoisoning = true;

            Main.buffNoTimeDisplay[Type] = false;
            Main.vanityPet[Type] = false;
            Main.lightPet[Type] = false;

            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;

            Main.pvpBuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
        
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ZifNpc>().LeadPoisoning = true;
        }
        
        public override bool ReApply(Player player, int time, int buffIndex)
        {
            player.buffTime[buffIndex] += time;
            return true;
        }
    }
}
