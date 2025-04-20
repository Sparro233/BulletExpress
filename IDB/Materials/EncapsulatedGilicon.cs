namespace BulletExpress.IDB.Materials
{
    public class EncapsulatedGilicon : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.rare = -1;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 25;

            Item.width = 16;
            Item.height = 16;
        }
    }
}