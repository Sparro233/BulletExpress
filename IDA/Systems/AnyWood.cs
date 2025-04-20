namespace BulletExpress
{
    public class AnyWood : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyWood = new RecipeGroup(() => "AnyWood", new int[]
            {
                ItemID.Wood, 
                620,
                619,
                911,
                621,
                2503,
                2504,
                2260,
                1729,
                5215
            });
            AnyWood.IconicItemId = ItemID.Wood;
            RecipeGroup.RegisterGroup("AnyWood", AnyWood);
        }
    }
}