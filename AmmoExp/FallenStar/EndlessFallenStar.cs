namespace BulletExpress.AmmoExp.FallenStar
{
    public class EndlessFallenStar : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.FallenStar;
            Item.shootSpeed = 1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FallenStar, 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}