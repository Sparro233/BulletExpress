namespace BulletExpress.AmmoExp.Coin
{
    public class EndlessPlatinumCoin : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.value = Item.sellPrice(100, 0, 0, 0);

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Coin;
            Item.shoot = ProjectileID.PlatinumCoin;
            Item.shootSpeed = 1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PlatinumCoin, 100)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}