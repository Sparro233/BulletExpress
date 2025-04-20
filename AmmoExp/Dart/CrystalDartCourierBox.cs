namespace BulletExpress.AmmoExp.Dart
{
    public class CrystalDartCourierBox : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Dart";
        public override void SetDefaults()
        {
            Item.damage = 28;
            Item.knockBack = 7;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Dart;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Dart.PotencyCrystalDart>();
            Item.shootSpeed = 2f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HallowedBar)
            .AddIngredient(ItemID.CrystalDart, 3996)
            .Register();
        }
    }
}