namespace BulletExpress.IDA.Buffs.Food
{
	public class WalnutDew : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //魔力消耗减少5%
            player.manaCost -= 0.05f;
        }
    }
}