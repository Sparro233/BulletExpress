namespace BulletExpress.AmmoExp.Flare
{
    public class EndlessBlueFlare : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Flare;
            Item.shoot = ProjectileID.BlueFlare;
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.BlueFlare, 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}