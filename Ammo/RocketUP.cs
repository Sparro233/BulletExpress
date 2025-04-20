namespace BulletExperss
{
    public class RocketUP : ModSystem
    {
        public override void AddRecipes()
        {
            //火箭I型升级
            Recipe RocketIUP = Recipe.Create(771, 200);
            RocketIUP.AddIngredient(ModContent.ItemType<BulletExpress.Ammo.Rocket.RocketZ>(), 200);
            RocketIUP.AddIngredient(ItemID.HellstoneBar);
            RocketIUP.AddTile(TileID.Anvils);
            RocketIUP.Register();
            //火箭III型升级
            Recipe RocketIIIUP = Recipe.Create(773, 200);
            RocketIIIUP.AddIngredient(771, 200);
            RocketIIIUP.AddIngredient(ItemID.HallowedBar);
            RocketIIIUP.AddTile(TileID.MythrilAnvil);
            RocketIIIUP.Register();
        }
    }
}