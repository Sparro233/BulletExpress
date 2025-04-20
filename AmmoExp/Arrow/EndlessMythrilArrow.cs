namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessMythrilArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.MythrilArrow>();
            Item.shootSpeed = 3.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.MythrilArrow>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}