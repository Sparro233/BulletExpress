namespace BulletExpress.IDA.Buffs.Potion
{
	public class SuperSummonPotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //增加魔力上限,增加召唤上限
            player.statManaMax2 += 40;
            player.maxMinions += 3;
        }
    }
}