namespace BulletExpress.IDA.Buffs.Potion
{
	public class GilicifiedII : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ZifPlayer>().GilicifiedII = true;
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            player.lifeRegen -= player.buffTime[buffIndex];
            player.buffTime[buffIndex] -= 1;
        }

        public override bool ReApply(Player player, int time, int buffIndex)
        {
            player.buffTime[buffIndex] += time;
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ZifNpc>().GilicifiedII = true;
        }
    }
}
