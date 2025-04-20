namespace BulletExpress.Ammo.Arrow
{
    public class EatersBiteArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.value = 8;
            Item.value = Item.sellPrice(0, 0, 0, 25);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow; 
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.EatersBiteArrow>();
            Item.shootSpeed = 4f;    
                    
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(300)
            .AddIngredient(ItemID.WoodenArrow, 300)
            .AddIngredient(1508)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}