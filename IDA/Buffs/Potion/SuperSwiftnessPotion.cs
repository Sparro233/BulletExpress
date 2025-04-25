namespace BulletExpress.IDA.Buffs.Potion
{
	public class SuperSwiftnessPotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.4f;
            player.GetCritChance(DamageClass.Generic) += 6f;
        }
    }
}