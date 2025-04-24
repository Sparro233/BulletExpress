namespace BulletExpress
{
    public class Device : ModSystem
    {
        public override void AddRecipes()
        {
            //探鱼器
            Recipe Device = Recipe.Create(3036);
            Device.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBatteries>(), 10);
            Device.AddRecipeGroup("AnyGoldBar",40);
            Device.AddTile(TileID.HeavyWorkBench);
            Device.Register();
            //R.E.K.3000
            Recipe DeviceI = Recipe.Create(3122);
            DeviceI.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBatteries>(), 30);
            DeviceI.AddRecipeGroup("AnySilverBar", 60);
            DeviceI.AddTile(TileID.HeavyWorkBench);
            DeviceI.Register();
            //全球定位仪
            Recipe DeviceII = Recipe.Create(395);
            DeviceII.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBatteries>(), 20);
            DeviceII.AddRecipeGroup("AnyCopperBar",40);
            DeviceII.AddTile(TileID.HeavyWorkBench);
            DeviceII.Register();
            //叶绿提炼机
            Recipe DeviceIII = Recipe.Create(5296);
            DeviceII.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBatteries>(), 40);
            DeviceIII.AddIngredient(1225, 18);
            DeviceIII.AddIngredient(997);
            DeviceIII.Register();
        }
    }
}