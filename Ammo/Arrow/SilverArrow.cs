namespace BulletExpress.Ammo.Arrow
{
    public class SilverArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(0, 0, 0, 10);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.SilverArrow>();
            Item.shootSpeed = 2.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
            .AddRecipeGroup("AnySilverBar")
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}