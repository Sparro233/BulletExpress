namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessHolyArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 13;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = 91;
            Item.shootSpeed = 3.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HolyArrow, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}