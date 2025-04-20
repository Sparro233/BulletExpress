namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessHellfireArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 13;
            Item.knockBack = 8;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.HellfireArrow;
            Item.shootSpeed = 6.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HellfireArrow, 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}