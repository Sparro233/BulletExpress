namespace BulletExpress
{
    public class AnyGoldBar : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyGoldBar = new RecipeGroup(() => "AnyGoldBar",
            new int[]
        {
            ItemID.GoldBar,
            ItemID.PlatinumBar
        });
            AnyGoldBar.IconicItemId = ItemID.GoldBar;
            RecipeGroup.RegisterGroup("AnyGoldBar", AnyGoldBar);
        }
    }
}