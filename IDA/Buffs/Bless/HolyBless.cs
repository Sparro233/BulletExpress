namespace BulletExpress.IDA.Buffs.Bless
{
	internal class HolyBless : ModBuff
    {
        public static readonly int DefenseBonus = 7;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 1;
            player.moveSpeed += 0.2f;
            Main.buffNoTimeDisplay[Type] = true;
        }
	}
}