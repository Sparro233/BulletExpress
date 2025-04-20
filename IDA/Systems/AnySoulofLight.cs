namespace BulletExpress
{
    public class AnySoulofLight : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnySoulofLight = new RecipeGroup(() => "AnySoulofLight",
            new int[]
            {
                520,
                521
            });
            AnySoulofLight.IconicItemId = ItemID.CursedFlame;
            RecipeGroup.RegisterGroup("AnySoulofLight", AnySoulofLight);
        }
    }
}