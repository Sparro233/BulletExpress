namespace BulletExpress.IDA.Buffs.Food
{
	public class MicroChocolate : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //伤害减免+1%
            player.endurance += 0.01f;
            //生命再生+1
            player.lifeRegen += 1;
        }
    }
}