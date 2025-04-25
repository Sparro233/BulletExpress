namespace BulletExpress.IDA.Buffs.Potion
{
    public class HatePotion : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            //生命上限
            player.statLifeMax2 -= 20;
            //生命再生
            player.lifeRegen -= 4;
            //伤害
            player.GetDamage(DamageClass.Generic) += 0.05f;
            //暴击
            player.GetCritChance(DamageClass.Generic) += 16f;
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
    }
}