namespace BulletExpress
{
    public class HerbalConversion : ModSystem
    {
        public override void AddRecipes()
        {
            /*请始终确保“添加配料”“添加瓷砖”“注册”前的名称是配方的名称
            不知道为什么自定义配方不能被独立分开
            可能是顶级命名空间不匹配导致的*/
            //太阳花
            Recipe recipe = Recipe.Create(307, 9);
            recipe.AddIngredient(313);
            recipe.Register();
            //月光草
            Recipe recipeI = Recipe.Create(308, 9);
            recipeI.AddIngredient(314);
            recipeI.Register();
            //闪耀根
            Recipe recipeII = Recipe.Create(309, 9);
            recipeII.AddIngredient(315);
            recipeII.Register();
            //死亡草
            Recipe recipeIII = Recipe.Create(310, 9);
            recipeIII.AddIngredient(316);
            recipeIII.Register();
            //幌菊
            Recipe recipeIV = Recipe.Create(311, 9);
            recipeIV.AddIngredient(317);
            recipeIV.Register();
            //火焰花
            Recipe recipeV = Recipe.Create(312, 9);
            recipeV.AddIngredient(318);
            recipeV.Register();
            //寒颤棘
            Recipe recipeVI = Recipe.Create(2357, 9);
            recipeVI.AddIngredient(2358);
            recipeVI.Register();
        }
    }
}