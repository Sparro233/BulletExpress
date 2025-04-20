namespace BulletExpress.IDA.Buffs.Bless
{
    internal class JyoratBless : ModBuff
    {
        public static readonly int DefenseBonus = 7;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.1f;
            player.lifeRegen += 10;
            player.GetDamage(DamageClass.Generic) += 0.1f;
            Main.buffNoTimeDisplay[Type] = true;
        }
	}
}