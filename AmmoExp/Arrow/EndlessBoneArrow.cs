namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessBoneArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 8;
            Item.knockBack = 2.5f;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.BoneArrowFromMerchant;
            Item.shootSpeed = 3.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.BoneArrow, 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}