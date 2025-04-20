namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessPhantasmArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 20;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.PhantasmArrow>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.PhantasmArrow>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}