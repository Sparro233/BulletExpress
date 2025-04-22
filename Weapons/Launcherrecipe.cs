namespace BulletExpress
{
    public class LauncherRecipe : ModSystem
    {
        public override void AddRecipes()
        {
            //Áñµ¯·¢ÉäÆ÷
            Recipe GrenadeLauncher = Recipe.Create(ItemID.GrenadeLauncher);
            GrenadeLauncher.AddRecipeGroup("AnyIronBar", 20);
            GrenadeLauncher.AddIngredient(ItemID.IllegalGunParts);
            GrenadeLauncher.AddIngredient(ItemID.SoulofMight, 20);
            GrenadeLauncher.AddTile(TileID.MythrilAnvil);
            GrenadeLauncher.Register();
            //»ð¼ý·¢ÉäÆ÷
            Recipe RocketLauncher = Recipe.Create(ItemID.RocketLauncher);
            RocketLauncher.AddRecipeGroup("AnyIronBar", 20);
            RocketLauncher.AddIngredient(ItemID.IllegalGunParts);
            RocketLauncher.AddIngredient(ItemID.SoulofSight, 20);
            RocketLauncher.AddTile(TileID.MythrilAnvil);
            RocketLauncher.Register();
        }
    }
}