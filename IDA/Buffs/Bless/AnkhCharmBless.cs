namespace BulletExpress.IDA.Buffs.Bless
{
	internal class AnkhCharmBless : ModBuff
    {
        public static readonly int DefenseBonus = 4;
        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ZifPlayer>().AnkhCharmBless = true;
            player.statDefense += DefenseBonus;
        }
	}
}