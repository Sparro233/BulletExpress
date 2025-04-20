namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessChlorophyteArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 16;
            Item.knockBack = 3.5f;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.ChlorophyteArrow;
            Item.shootSpeed = 4.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ChlorophyteArrow, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}