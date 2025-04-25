namespace BulletExpress.IDA.Buffs.Potion
{
	public class SuperNutrientPotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //生命恢复速度提升
            player.lifeRegen += 100;
            Main.buffNoSave[Type] = true;
        }
    }
}