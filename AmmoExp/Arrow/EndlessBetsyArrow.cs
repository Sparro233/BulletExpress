namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessBetsyArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 13;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 12, 0, 0);
            Item.rare = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.DD2BetsyArrow;
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.BetsyArrow>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}