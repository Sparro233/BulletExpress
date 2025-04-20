namespace BulletExpress.Ammo.Arrow
{
    public class ManganeseArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(0, 0, 0, 5);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.ManganeseArrow>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
            .AddIngredient(ModContent.ItemType<IDB.Materials.ManganeseBar>())
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}