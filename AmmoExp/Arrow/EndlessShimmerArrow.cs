namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessShimmerArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.ShimmerArrow;
            Item.shootSpeed = 3f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ShimmerArrow, 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}