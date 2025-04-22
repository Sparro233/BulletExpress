namespace BulletExpress
{
    public class Device : ModSystem
    {
        public override void AddRecipes()
        {
            //探鱼器
            Recipe Device = Recipe.Create(3036);
            Device.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBatteries>(), 5);
            Device.AddRecipeGroup("AnyGoldBar",40);
            Device.AddTile(TileID.HeavyWorkBench);
            Device.Register();
            //R.E.K.3000
            Recipe DeviceI = Recipe.Create(3122);
            DeviceI.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBar>(), 20);
            DeviceI.AddRecipeGroup("AnySilverBar", 60);
            DeviceI.AddTile(TileID.HeavyWorkBench);
            DeviceI.Register();
            //全球定位仪
            Recipe DeviceII = Recipe.Create(395);
            DeviceII.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBar>(), 20);
            DeviceII.AddRecipeGroup("AnyCopperBar",40);
            DeviceII.AddTile(TileID.HeavyWorkBench);
            DeviceII.Register();
        }
    }
}