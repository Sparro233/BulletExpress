namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessCrossGooSArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 50, 0, 0);
            Item.rare = -11;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.GooSArrow>();
            Item.shootSpeed = 2.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.CrossGooSArrow>(), 9999)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}