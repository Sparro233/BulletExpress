namespace BulletExpress.IDA.Buffs.Potion
{
	public class MagicSlagPotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //魔力上限增加
            player.statManaMax2 += 40;
            //魔力恢复增加
            player.manaRegen += 5;
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.vanityPet[Type] = false;
            Main.lightPet[Type] = false;
            Main.pvpBuff[Type] = false;
        }
    }
}