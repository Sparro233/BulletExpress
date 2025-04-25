namespace BulletExpress.IDA.Buffs
{
	public class Tetanus : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ZifPlayer>().Tetanus = true;

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
            npc.GetGlobalNPC<ZifNpc>().Tetanus = true;
        }

        public override bool ReApply(Player player, int time, int buffIndex)
        {
            player.buffTime[buffIndex] += time;
            return true;
        }
    }
}
