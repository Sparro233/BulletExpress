namespace BulletExpress
{
    public class AnyDirtBlock : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyDirtBlock = new RecipeGroup(() => "AnyDirtBlock", new int[]
            {
                ItemID.DirtBlock, 
                ItemID.AshBlock,
                ItemID.MudBlock
            });
            AnyDirtBlock.IconicItemId = ItemID.DirtBlock;
            RecipeGroup.RegisterGroup("AnyDirtBlock", AnyDirtBlock);
        }
    }
}