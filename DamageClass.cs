namespace BulletExpress
{
    public class HortiDamage : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            //此方法让你的伤害类型能够享受其它伤害类型的加成, 也包括通用伤害类型
            //Default (默认), 是的你已经猜到了, 就是默认的伤害类型. 它不会受到任何特定伤害类型或通用伤害类型加成的影响
            //Geberic (通用), 与之相反, 受所有伤害类型的加成影响. 这是除了 Default 以外所有伤害类型的基础
            if (damageClass == DamageClass.Summon)
            {
                return new StatInheritanceData(
                    //伤害继承
                    damageInheritance: 1f, 
                    //暴击率继承
                    critChanceInheritance: 1f, 
                    //攻速继承
                    attackSpeedInheritance: 1f, 
                    //盔甲穿透继承
                    armorPenInheritance: 1f, 
                    //击退继承
                    knockbackInheritance: 1f 
                ); 
            }
            return StatInheritanceData.Full;
        }

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            //此方法允许你使你的伤害类型触发本该由其它伤害类型触发的效果 (如岩浆石只对近战伤害生效)
            if (damageClass == DamageClass.Melee && damageClass == DamageClass.Summon)
                return true;
            return false;
        }

        public override void SetDefaultStats(Player player)
        {
            player.GetKnockback<EnergyDamage>() -= 4;
            //此方法让你设置此伤害类型的默认属性加成 (像原版的伤害默认有+4%暴击率)
            //你也可以在这里写攻速 (GetAttackSpeed), 额外伤害 (GetDamage), 暴击率 (GetCritChance), 鸡腿 (GetKnockback), 穿透 (GetArmorPenetration)
        }

        //此属性决定此伤害类型是否使用标准的暴击计算公式
        public override bool UseStandardCritCalcs => false;
    }

    public class EnergyDamage : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Ranged)
            {
                return new StatInheritanceData(
                    damageInheritance: 1f,
                    critChanceInheritance: 1f,
                    attackSpeedInheritance: 1f,
                    armorPenInheritance: 1f,
                    knockbackInheritance: 1f
                );
            }
            return StatInheritanceData.Full;
        }
        
        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            if (damageClass == DamageClass.Ranged && damageClass == DamageClass.Magic)
                return true;
            return false;
        }
        
        public override void SetDefaultStats(Player player)
        {
            player.GetCritChance<EnergyDamage>() += 4;
            player.GetKnockback<EnergyDamage>() += 4;
            player.GetArmorPenetration<EnergyDamage>() += 255;
        }
        
        public override bool UseStandardCritCalcs => true;
    }
}