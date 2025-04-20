namespace BulletExpress.IDA.Buffs.Flog
{
    public class LightMark : ModBuff
    {
        public static readonly int TagDamage = 6;
        public static readonly int TagDamagePercent = 6;
        public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsATagBuff[Type] = true;
        }
    }
}