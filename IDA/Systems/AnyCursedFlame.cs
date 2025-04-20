namespace BulletExpress
{
    public class AnyCursedFlame : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup AnyCursedFlame = new RecipeGroup(() => "AnyCursedFlame", new int[]
            {
                ItemID.CursedFlame,
                ItemID.Ichor
            });
            AnyCursedFlame.IconicItemId = ItemID.CursedFlame;
            RecipeGroup.RegisterGroup("AnyCursedFlame", AnyCursedFlame);
        }
    }
}