namespace BulletExpress.Ammo.Arrow
{
    public class HorizonTurbulenceArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 8;
            Item.knockBack = 1;
            Item.value = 4;
            Item.rare = 2;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.HorizonArrow>();
            Item.shootSpeed = 4.8f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(333)
            .AddIngredient(ItemID.WoodenArrow, 333)
            .AddIngredient(4075)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}