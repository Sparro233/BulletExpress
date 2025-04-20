namespace BulletExpress.Ammo.Arrow
{
    public class OrichalcumArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.OrichalcumArrow>();
            Item.shootSpeed = 2.5f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)            
            .AddIngredient(ItemID.OrichalcumBar)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}