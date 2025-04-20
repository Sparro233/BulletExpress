namespace BulletExpress
{
    public class NibbledOrMAGIII : ModSystem
    {
        public override void AddRecipes()
        {
            RecipeGroup NibbledOrMAGIII = new RecipeGroup(() => "NibbledOrMAGIII", new int[]
            {
                ModContent.ItemType<BulletExpress.Weapons.Ranged.Ter.Nibbled>(),
                ModContent.ItemType<BulletExpress.Weapons.Ranged.Ter.MAGIII>()
            });
            NibbledOrMAGIII.IconicItemId = ModContent.ItemType<BulletExpress.Weapons.Ranged.Ter.Nibbled>();
            RecipeGroup.RegisterGroup("NibbledOrMAGIII", NibbledOrMAGIII);
        }
    }
}