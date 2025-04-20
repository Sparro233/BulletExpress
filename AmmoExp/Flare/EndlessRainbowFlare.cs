namespace BulletExpress.AmmoExp.Flare
{
    public class EndlessRainbowFlare : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Flare;
            Item.shoot = ProjectileID.RainbowFlare;
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.RainbowFlare, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}