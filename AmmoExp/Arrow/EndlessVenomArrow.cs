namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessVenomArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 19;
            Item.knockBack = 4.2f;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.VenomArrow;
            Item.shootSpeed = 4.3f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.VenomArrow, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}