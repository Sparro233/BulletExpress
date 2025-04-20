namespace BulletExpress
{
    public class AnyWormTooth : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyWormTooth = new RecipeGroup(() => "AnyWormTooth", new int[]
            {
                ItemID.WormTooth,
                ItemID.Vertebrae
            });
            AnyWormTooth.IconicItemId = ItemID.WormTooth;
            RecipeGroup.RegisterGroup("AnyWormTooth", AnyWormTooth);
        }
    }
}