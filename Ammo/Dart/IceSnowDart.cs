namespace BulletExpress.Ammo.Dart
{
    public class IceSnowDart : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.knockBack = 0.25f;
            Item.value = 1;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Dart;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Dart.IceSnowDart>();
            Item.shootSpeed = 3.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
            .AddIngredient(664)
            .Register();
        }
    }
}