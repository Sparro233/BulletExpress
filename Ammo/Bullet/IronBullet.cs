namespace BulletExpress.Ammo.Bullet
{
    public class IronBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.knockBack = 3.5f;
            Item.value = Item.sellPrice(0, 0, 0, 5);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.IronBullet>();
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
            .AddIngredient(ItemID.IronBar)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}