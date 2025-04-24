namespace BulletExpress
{
    public class Alchemy : ModSystem
    {
        public override void AddRecipes()
        {
            //炼金术(铂金)
            Recipe Alchemy = Recipe.Create(ItemID.PlatinumOre);
            Alchemy.AddRecipeGroup("AnyDirtBlock", 9);
            Alchemy.AddTile(TileID.HeavyWorkBench);
            Alchemy.Register();
        }
    }
}
