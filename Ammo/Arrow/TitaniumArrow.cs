namespace BulletExpress.Ammo.Arrow
{
    public class TitaniumArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 10;
            Item.value = Item.sellPrice(0, 0, 0, 20);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.TitaniumArrow>();
            Item.shootSpeed = 3f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddIngredient(ItemID.TitaniumBar)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}