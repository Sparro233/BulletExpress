namespace BulletExpress.IDA.Buffs.Potion
{
	public class PotencySwiftnessPotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.2f;
            player.GetCritChance(DamageClass.Generic) += 3f;
        }
    }
}