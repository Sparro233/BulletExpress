namespace BulletExpress
{
    public class AnySilverBar : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnySilverBar = new RecipeGroup(() => "AnySilverBar", new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            });
            AnySilverBar.IconicItemId = ItemID.SilverBar;
            RecipeGroup.RegisterGroup("AnySilverBar", AnySilverBar);
        }
    }
}