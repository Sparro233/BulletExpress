namespace BulletExpress.IDA.Buffs.Potion
{
	public class PotencyMagicSlagPotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //魔力上限增加x
            player.statManaMax2 += 80;
            //魔力恢复增加
            player.manaRegen += 10;
        }
    }
}