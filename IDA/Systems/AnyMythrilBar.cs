namespace BulletExpress
{
    public class AnyMythrilBar : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyMythrilBar = new RecipeGroup(() => "AnyMythrilBar", new int[]
            {
                ItemID.MythrilBar,
                ItemID.OrichalcumBar
            });
            AnyMythrilBar.IconicItemId = ItemID.MythrilBar; 
            RecipeGroup.RegisterGroup("AnyMythrilBar", AnyMythrilBar);
        }
    }
}