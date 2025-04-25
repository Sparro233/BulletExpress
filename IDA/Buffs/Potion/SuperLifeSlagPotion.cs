namespace BulletExpress.IDA.Buffs.Potion
{
	public class SuperLifeSlagPotion : ModBuff
    {
        public static readonly int DefenseBonus = 2;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            //生命再生提升，生命上限增加
            player.statDefense += DefenseBonus;
            player.lifeRegen += 4;
            player.statLifeMax2 += 60;
        }
    }
}