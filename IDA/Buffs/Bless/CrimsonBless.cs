namespace BulletExpress.IDA.Buffs.Bless
{
    internal class CrimsonBless : ModBuff
    {
        public static readonly int DefenseBonus = 7;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 4;
            Main.buffNoTimeDisplay[Type] = true;
        }
	}
}