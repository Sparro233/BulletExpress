namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessUnholyArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.UnholyArrow;
            Item.shootSpeed = 3.4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.UnholyArrow, 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}