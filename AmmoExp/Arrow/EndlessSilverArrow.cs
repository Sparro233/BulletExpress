namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessSilverArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.SilverArrow>();
            Item.shootSpeed = 2.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.SilverArrow>(), 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}