namespace BulletExpress.IDA.Buffs
{
	public class KillTheSoCalledGods : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            if (Main.rand.NextBool(3))
            {
                Dust d = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<IDA.Powders.FlawlessI>());
                d.velocity *= 0.7f;
            }
            if (player.lifeRegen > 0)
            {
                player.lifeRegen = 0;
            }
            player.lifeRegenTime = 0;
            player.lifeRegen -= 20;
            player.buffTime[buffIndex] -= 2;

            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.vanityPet[Type] = false;
            Main.lightPet[Type] = false;
            Main.pvpBuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ZifNpc>().KillTheSoCalledGods = true;
        }
    }
}