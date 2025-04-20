namespace BulletExpress.AmmoExp.Gel
{
    public class EndlessGel : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Gel;
            Item.shootSpeed = 1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Gel, 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}