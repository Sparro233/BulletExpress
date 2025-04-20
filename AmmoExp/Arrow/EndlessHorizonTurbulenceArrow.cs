namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessHorizonTurbulenceArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.HorizonArrow>();
            Item.shootSpeed = 4.8f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.HorizonTurbulenceArrow>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}