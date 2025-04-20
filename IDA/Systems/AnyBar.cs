namespace BulletExpress
{
    public class AnyBar : ModSystem
    {
        public override void AddRecipes()
        {
            //��Ϸ����ʾ�ĺϳ��������
            RecipeGroup AnyBar = new RecipeGroup(() => "AnyBar", new int[]
            {
                //��ϳ�������ӵ���Ʒ 
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
            //���Ǻϳ�����ʾ����ͼ���ĸ���Ʒ������Ʒ������
            AnyBar.IconicItemId = ItemID.IronBar;
            //����Ϸע������ϳ��飬���������Ҳ��֮��ʹ�úϳ������������
            RecipeGroup.RegisterGroup("AnyBar", AnyBar);
        }
    }
}