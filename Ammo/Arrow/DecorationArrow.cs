namespace BulletExpress.Ammo.Arrow
{
    public class DecorationArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.value = Item.sellPrice(0, 0, 0, 15);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.DecorationArrow>();
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(ItemID.WoodenArrow, 150)
            .AddIngredient(1344)
            .AddIngredient(ItemID.Vine)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}