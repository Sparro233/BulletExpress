namespace BulletExperss
{
    public class EndlessAmmoBox : ModSystem
    {
        public override void AddRecipes()
        {
            //无尽箭矢箱
            Recipe EndlessArrowBox = Recipe.Create(ItemID.EndlessQuiver);
            EndlessArrowBox.AddIngredient(ItemID.WoodenArrow, 3996);
            EndlessArrowBox.AddTile(TileID.WorkBenches);
            EndlessArrowBox.Register();
            //无尽子弹箱
            Recipe EndlessBulletBox = Recipe.Create(ItemID.EndlessMusketPouch);
            EndlessBulletBox.AddIngredient(ItemID.MusketBall, 3996);
            EndlessBulletBox.AddTile(TileID.Anvils);
            EndlessBulletBox.Register();
        }
    }
}