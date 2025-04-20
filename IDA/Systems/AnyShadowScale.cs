namespace BulletExpress
{
    public class AnyShadowScale : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyShadowScale = new RecipeGroup(() => "AnyShadowScale",
            new int[]
        {
            ItemID.ShadowScale,
            1329
        });
            AnyShadowScale.IconicItemId = ItemID.ShadowScale;
            RecipeGroup.RegisterGroup("AnyShadowScale", AnyShadowScale);
        }
    }
}