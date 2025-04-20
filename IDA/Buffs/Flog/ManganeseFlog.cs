namespace BulletExpress.IDA.Buffs.Flog
{
    public class ManganeseFlog : ModBuff
    {
        public static readonly int TagDamage = 12;
        public static readonly int TagDamagePercent = 12;
        public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsATagBuff[Type] = true;
        }
    }
}