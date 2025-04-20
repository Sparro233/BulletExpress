namespace BulletExpress
{
    public class AnyBar : ModSystem
    {
        public override void AddRecipes()
        {
            //游戏中显示的合成组的名字
            RecipeGroup AnyBar = new RecipeGroup(() => "AnyBar", new int[]
            {
                //向合成组中添加的物品 
                ModContent.ItemType<BulletExpress.IDB.Materials.ManganeseBar>(),
                ItemID.CopperBar,
                ItemID.TinBar,
                ItemID.IronBar,
                ItemID.LeadBar,
                ItemID.SilverBar,
                ItemID.TungstenBar,
                ItemID.GoldBar,
                ItemID.PlatinumBar
            });
            //这是合成组显示的贴图是哪个物品，填物品的类型
            AnyBar.IconicItemId = ItemID.IronBar;
            //向游戏注册这个合成组，这里的名字也是之后使用合成组的文字索引
            RecipeGroup.RegisterGroup("AnyBar", AnyBar);
        }
    }
}