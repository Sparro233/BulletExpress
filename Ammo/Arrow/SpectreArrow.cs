namespace BulletExpress.Ammo.Arrow
{
    public class SpectreArrow: ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.value = Item.sellPrice(0, 0, 0, 25);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.SpectreArrow>();
            Item.shootSpeed = 1f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(300)
            .AddIngredient(3261)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}