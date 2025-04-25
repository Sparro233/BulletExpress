namespace BulletExpress.IDA.Buffs.Potion
{
	public class GilicifiedI : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ZifPlayer>().GilicifiedI = true;
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            player.buffTime[buffIndex] -= 1;
            player.lifeRegen -= player.buffTime[buffIndex];
        }
        
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ZifNpc>().GilicifiedI = true;
        }
        
        public override bool ReApply(Player player, int time, int buffIndex)
        {
            player.buffTime[buffIndex] += time;
            return true;
        }
    }
}
