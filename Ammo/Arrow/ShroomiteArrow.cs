namespace BulletExpress.Ammo.Arrow
{
    public class ShroomiteArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 18;
            Item.value = Item.sellPrice(0, 0, 0, 25);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.ShroomiteArrow>();
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(300)
            .AddIngredient(ItemID.ShroomiteBar)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}