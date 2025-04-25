namespace BulletExpress.IDA.Buffs.Potion
{
    public class SuperHatePotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //生命上限
            player.statLifeMax2 -= 80;
            //生命再生
            player.lifeRegen -= 8;
            //伤害
            player.GetDamage(DamageClass.Generic) += 0.1f;
            //暴击
            player.GetCritChance(DamageClass.Generic) += 32f;
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
    }
}