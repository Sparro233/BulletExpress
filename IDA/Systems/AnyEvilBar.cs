namespace BulletExpress
{
    public class AnyEvilBar : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyEvilBar = new RecipeGroup(() => "AnyEvilBar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });
            AnyEvilBar.IconicItemId = ItemID.DemoniteBar;
            RecipeGroup.RegisterGroup("AnyEvilBar", AnyEvilBar);
        }
    }
}