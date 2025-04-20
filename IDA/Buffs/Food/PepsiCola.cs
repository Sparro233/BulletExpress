namespace BulletExpress.IDA.Buffs.Food
{
	public class PepsiCola : ModBuff
    {
        public static readonly int DefenseBonus = 2;
        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);
        public override void Update(Player player, ref int buffIndex)
        {
            //����+2
            player.statDefense += DefenseBonus;
        }
    }
}