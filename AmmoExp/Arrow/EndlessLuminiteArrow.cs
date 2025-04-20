namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessLuminiteArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 15;
            Item.knockBack = 3.5f;
            Item.value = Item.sellPrice(0, 50, 0, 0);
            Item.rare = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = 639;
            Item.shootSpeed = 3f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3568, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}