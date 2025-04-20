namespace BulletExpress.IDA.Buffs
{
    internal class GardeningHunt : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ZifPlayer>().GardeningHunt = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
	}
}