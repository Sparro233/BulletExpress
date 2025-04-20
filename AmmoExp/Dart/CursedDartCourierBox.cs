namespace BulletExpress.AmmoExp.Dart
{
    public class CursedDartCourierBox : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Dart";
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.knockBack = 4.4f;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Dart;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Dart.PotencyCursedDart>();
            Item.shootSpeed = 3f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HallowedBar)
            .AddIngredient(ItemID.CursedDart, 3996)
            .Register();
        }
    }
}