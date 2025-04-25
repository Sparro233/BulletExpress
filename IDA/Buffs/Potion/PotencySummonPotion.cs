namespace BulletExpress.IDA.Buffs.Potion
{
	public class PotencySummonPotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //增加魔力上限
            player.statManaMax2 += 20;
            //增加召唤上限
            player.maxMinions += 2;
        }
    }
}