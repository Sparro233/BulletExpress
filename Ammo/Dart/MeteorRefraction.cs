namespace BulletExpress.Ammo.Dart
{
    public class MeteorRefraction : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.knockBack = 3.25f;
            Item.value = 5;
            Item.rare = 1;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Dart;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Dart.MeteorRefraction>();
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(70)
            .AddIngredient(ItemID.MeteoriteBar)
            .Register();
        }
    }
}