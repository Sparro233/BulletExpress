namespace BulletExpress.IDA.Buffs.Potion
{
	public class SuperLiquidLightPotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //魔力消耗减少%
            player.manaCost -= 0.4f;
        }
    }
}