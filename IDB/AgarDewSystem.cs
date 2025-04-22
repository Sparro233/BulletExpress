namespace BulletExpress
{
    public class AgarDewSystem : ModSystem
    {
        public override void AddRecipes()
        {
            //蜂蜡
            Recipe AgarDew = Recipe.Create(2431, 9);
            AgarDew.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.AgarDew>());
            AgarDew.AddTile(355);
            AgarDew.Register();
            //蜂巢 
            Recipe ADII = Recipe.Create(1124, 9);
            ADII.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.AgarDew>());
            ADII.AddTile(355);
            ADII.Register();
            //蜂蜜块
            Recipe ADIII = Recipe.Create(1125, 9);
            ADIII.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.AgarDew>());
            ADIII.AddTile(172);
            ADIII.Register();
            //松脆蜂蜜块
            Recipe ADIV = Recipe.Create(1127, 9);
            ADIV.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.AgarDew>());
            ADIV.AddTile(215);
            ADIV.Register();
        }
    }
}