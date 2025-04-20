namespace BulletExpress.AmmoExp.Coin
{
    public class EndlessSilverCoin : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.value = Item.sellPrice(0, 1, 0, 0);

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Coin;
            Item.shoot = ProjectileID.SilverCoin;
            Item.shootSpeed = 1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.SilverCoin, 100)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}