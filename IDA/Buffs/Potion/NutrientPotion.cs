namespace BulletExpress.IDA.Buffs.Potion
{
	public class NutrientPotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //生命恢复速度提升
            player.lifeRegen += 50;
            Main.buffNoSave[Type] = true;
        }
    }
}