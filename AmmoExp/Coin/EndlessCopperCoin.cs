namespace BulletExpress.AmmoExp.Coin
{
    public class EndlessCopperCoin : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.value = Item.sellPrice(0, 0, 1, 0);

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Coin;
            Item.shoot = ProjectileID.CopperCoin;
            Item.shootSpeed = 1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.CopperCoin, 100)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}