namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessEatersBiteArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.EatersBiteArrow>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.EatersBiteArrow>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}