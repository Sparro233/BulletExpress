namespace BulletExpress.Ammo.Bullet
{
    public class HorizonTearBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = -11;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.HorizonBullet>();
            Item.shootSpeed = 4f;
            
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