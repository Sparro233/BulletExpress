namespace BulletExpress
{
    public class SturdyFossilSystem : ModSystem
    {
        public override void AddRecipes()
        {
            //雷霆法杖
            Recipe recipe = Recipe.Create(4062);
            recipe.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBar>(), 10);
            recipe.AddIngredient(3380, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            //魔法海螺
            Recipe recipeI = Recipe.Create(4263);
            recipeI.AddIngredient(3380, 10);
            recipeI.AddIngredient(999, 8);
            recipeI.AddIngredient(4072, 3);
            recipeI.Register();
            //恶魔海螺
            Recipe recipeII = Recipe.Create(4819);
            recipeII.AddIngredient(175, 10);
            recipeII.AddIngredient(154, 8);
            recipeII.AddIngredient(4073, 3);
            recipeII.Register();
            //猫神雕像
            Recipe recipeIII = Recipe.Create(4276);
            recipeIII.AddIngredient(4051, 10);
            recipeIII.AddIngredient(3380, 5);
            recipeIII.Register();
        }
    }
}