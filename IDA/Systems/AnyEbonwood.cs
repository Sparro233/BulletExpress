namespace BulletExpress
{
    public class AnyEbonwood : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyEbonwood = new RecipeGroup(() => "AnyEbonwood",
            new int[]
            {
                ItemID.Ebonwood,
                911
            });
            AnyEbonwood.IconicItemId = 619;
            RecipeGroup.RegisterGroup("AnyEbonwood", AnyEbonwood);
        }
    }
}