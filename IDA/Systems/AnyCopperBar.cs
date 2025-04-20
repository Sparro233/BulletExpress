namespace BulletExpress
{
    public class AnyCopperBar : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyCopperBar = new RecipeGroup(() => "AnyCopperBar",
            new int[]
        {
            ItemID.CopperBar,
            ItemID.TinBar
        });
            AnyCopperBar.IconicItemId = ItemID.CopperBar;
            RecipeGroup.RegisterGroup("AnyCopperBar", AnyCopperBar);
        }
    }
}