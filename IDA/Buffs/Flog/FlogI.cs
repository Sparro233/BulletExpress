namespace BulletExpress.IDA.Buffs.Flog
{
    public class FlogI : ModBuff
    {
        public static readonly int TagDamage = 4;
        public static readonly int TagDamagePercent = 4;
        public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;
        public override void SetStaticDefaults()
        {
            //这允许对NPC施加减益效果，否则NPC将对所有减益效果免疫。
            //其他MOD可能会出于不同的目的检查它。
            BuffID.Sets.IsATagBuff[Type] = true;
        }
    }
}