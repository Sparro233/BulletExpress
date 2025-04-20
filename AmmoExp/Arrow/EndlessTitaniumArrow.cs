namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessTitaniumArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.TitaniumArrow>();
            Item.shootSpeed = 3f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.TitaniumArrow>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}