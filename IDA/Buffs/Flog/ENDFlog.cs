namespace BulletExpress.IDA.Buffs.Flog
{
    public class ENDFlog : ModBuff
    {
        public static readonly int TagDamage = 50;
        public static readonly int TagDamagePercent = 50;
        public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsATagBuff[Type] = true;
        }
    }
}