namespace BulletExpress.AmmoExp.Flare
{
    public class EndlessSouthernCrossFlashbang : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = 3;

            Item.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Item.ammo = AmmoID.Flare;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Flare.SouthernCrossFlashbang>();
            Item.shootSpeed = 10f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Flare.SouthernCrossFlashbang>(), 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}