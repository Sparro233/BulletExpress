namespace BulletExpress.Ammo.Arrow
{
    public class BoomCrystalArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 10;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 0, 0, 15);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.BoomCrystalArrow>();
            Item.shootSpeed = 7f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(ItemID.WoodenArrow, 150)
            .AddIngredient(ItemID.CrystalShard)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}