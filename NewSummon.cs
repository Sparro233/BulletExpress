namespace BulletExpress
{
    public class NewSummon : ModPlayer
    {
        public bool SummonID1;
        public bool SummonID2;
        public bool SummonID3;
        public bool SummonID4;
        public override void ResetEffects()
        {
            SummonID1 = false;
            SummonID2 = false;
            SummonID3 = false;
            SummonID4 = false;
        }
    }
}