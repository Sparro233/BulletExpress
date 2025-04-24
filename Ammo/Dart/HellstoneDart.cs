namespace BulletExpress.Ammo.Dart
{
    public class HellstoneDart : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.knockBack = 1.25f;
            Item.value = Item.sellPrice(0, 0, 0, 30);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Dart;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Dart.HellstoneDart>();
            Item.shootSpeed = 3f;
            base.SetDefaults();
        }
        
        public override void AddRecipes()
        {
            Recipe modRecipe = Recipe.Create(Type, 150);
            modRecipe.AddIngredient(ItemID.HellstoneBar)
            .Register();
        }
    }
}
