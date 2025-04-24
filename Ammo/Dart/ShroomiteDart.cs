namespace BulletExpress.Ammo.Dart
{
    public class ShroomiteDart : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.knockBack = 1.5f;
            Item.value = 20;
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Dart;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Dart.ShroomiteDart>();
            Item.shootSpeed = 4.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(ItemID.ShroomiteBar)
            .Register();
        }
    }
}