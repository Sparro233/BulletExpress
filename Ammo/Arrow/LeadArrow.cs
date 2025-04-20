namespace BulletExpress.Ammo.Arrow
{
    public class LeadArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(0, 0, 0, 5);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.LeadArrow>();
            Item.shootSpeed = 2f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
            .AddRecipeGroup("AnyIronBar")
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}