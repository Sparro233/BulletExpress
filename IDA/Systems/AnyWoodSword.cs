namespace BulletExpress
{
    public class AnyWoodSword : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyWoodSword = new RecipeGroup(() => "AnyWoodSword", new int[]
            {
                24,
                653,
                656,
                659,
                921,
                2517,
                2745,
                5284
            });
            AnyWoodSword.IconicItemId = 24;
            RecipeGroup.RegisterGroup("AnyWoodSword", AnyWoodSword);
        }
    }
}