namespace BulletExpress.Ammo.Bullet
{
    public class ShroomiteBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.knockBack = 1.25f;
            Item.value = Item.sellPrice(0, 0, 0, 25);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.ShroomiteBullet>();
            Item.shootSpeed = 4f;
            
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