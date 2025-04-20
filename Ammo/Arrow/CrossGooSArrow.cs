namespace BulletExpress.Ammo.Arrow
{
    public class CrossGooSArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 100;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = -11;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.GooSArrow>();
            Item.shootSpeed = 2.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(400)
            .AddIngredient(ItemID.LunarBar)
            .AddIngredient(ItemID.ChlorophyteBar)
            .AddIngredient(ItemID.HellstoneBar)
            .AddRecipeGroup("AnyEvilBar")
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}