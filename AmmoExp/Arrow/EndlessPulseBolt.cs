namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessPulseBolt : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 22;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = 357;
            Item.shootSpeed = 1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.PulseBolt>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}