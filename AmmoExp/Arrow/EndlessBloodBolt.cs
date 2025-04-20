namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessBloodBolt : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.BloodBolt>();
            Item.shootSpeed = 2f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.BloodBolt>(), 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}