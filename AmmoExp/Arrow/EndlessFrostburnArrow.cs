namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessFrostburnArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 7;
            Item.knockBack = 2.2f;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.FrostburnArrow;
            Item.shootSpeed = 3.75f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FrostburnArrow, 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}