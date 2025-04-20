namespace BulletExpress.IDA.Buffs.Bless
{
    internal class DecayBless : ModBuff
    {
        public static readonly int DefenseBonus = 7;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.06f;
            Main.buffNoTimeDisplay[Type] = true;
        }
	}
}