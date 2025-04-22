namespace BulletExpress.IDB.Materials
{
    public class StrayCotton : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 0, 20);

            Item.ResearchUnlockCount = 10;
            Item.maxStack = 9999;

            Item.width = 16;
            Item.height = 16;
        }
    }
}