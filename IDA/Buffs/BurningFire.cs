namespace BulletExpress.IDA.Buffs
{
    internal class BurningFire : ModBuff
    {
        public static readonly int DefenseBonus = 7;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 7;
            player.GetDamage(DamageClass.Generic) += 0.38f;// 伤害增加
        }

        public override bool ReApply(Player player, int time, int buffIndex)
        {
            if(player.buffTime[buffIndex] <= 600)
            {
                player.buffTime[buffIndex] += time;
            }
            return true;
        }
    }
}