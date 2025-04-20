namespace BulletExpress
{
    public class HerbalConversion : ModSystem
    {
        public override void AddRecipes()
        {
            /*请始终确保“添加配料”“添加瓷砖”“注册”前的名称是配方的名称
            不知道为什么自定义配方不能被独立分开
            可能是顶级命名空间不匹配导致的*/
            //炼金术
            Recipe Alchemy = Recipe.Create(ItemID.PlatinumOre);
            Alchemy.AddRecipeGroup("AnyDirtBlock", 9);
            Alchemy.AddTile(TileID.HeavyWorkBench);
            Alchemy.Register();
            //太阳花
            Recipe recipe = Recipe.Create(307, 9);
            recipe.AddIngredient(313);
            recipe.Register();
            //月光草
            Recipe recipe1 = Recipe.Create(308, 9);
            recipe1.AddIngredient(314);
            recipe1.Register();
            //闪耀根
            Recipe recipe2 = Recipe.Create(309, 9);
            recipe2.AddIngredient(315);
            recipe2.Register();
            //死亡草
            Recipe recipe6 = Recipe.Create(310, 9);
            recipe6.AddIngredient(316);
            recipe6.Register();
            //幌菊
            Recipe recipe3 = Recipe.Create(311, 9);
            recipe3.AddIngredient(317);
            recipe3.Register();
            //火焰花
            Recipe recipe4 = Recipe.Create(312, 9);
            recipe4.AddIngredient(318);
            recipe4.Register();
            //寒颤棘
            Recipe recipe5 = Recipe.Create(2357, 9);
            recipe5.AddIngredient(2358);
            recipe5.Register();
            //探鱼器
            Recipe Device = Recipe.Create(3036);
            Device.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBar>(), 30);
            Device.AddRecipeGroup("AnyGoldBar",30);
            Device.AddTile(TileID.HeavyWorkBench);
            Device.Register();
            //R.E.K.3000
            Recipe DeviceI = Recipe.Create(3122);
            DeviceI.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBar>(), 40);
            DeviceI.AddRecipeGroup("AnySilverBar", 40);
            DeviceI.AddTile(TileID.HeavyWorkBench);
            DeviceI.Register();
            //全球定位仪
            Recipe DeviceII = Recipe.Create(395);
            DeviceII.AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBar>(), 20);
            DeviceII.AddRecipeGroup("AnyCopperBar",20);
            DeviceII.AddTile(TileID.HeavyWorkBench);
            DeviceII.Register();
        }
    }
}