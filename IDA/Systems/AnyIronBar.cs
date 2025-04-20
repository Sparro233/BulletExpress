namespace BulletExpress
{
    public class AnyIronBar : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyIronBar = new RecipeGroup(() => "AnyIronBar", new int[]
            {
                ItemID.IronBar,
                ItemID.LeadBar
            });
            AnyIronBar.IconicItemId = ItemID.IronBar;
            RecipeGroup.RegisterGroup("AnyIronBar", AnyIronBar);
        }
    }
}