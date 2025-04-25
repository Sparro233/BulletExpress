namespace BulletExpress.IDA.Buffs.Potion
{
	public class LifeSlagPotion : ModBuff
    {
        public static readonly int DefenseBonus = 1;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            //防御提升，生命再生提升，生命上限增加
            player.statDefense += DefenseBonus;
            player.lifeRegen += 2;
            player.statLifeMax2 += 20;

            Main.buffNoTimeDisplay[Type] = false;
            Main.vanityPet[Type] = false;
            Main.lightPet[Type] = false;

            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;

            Main.pvpBuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
    }
}