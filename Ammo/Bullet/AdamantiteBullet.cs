namespace BulletExpress.Ammo.Bullet
{
    public class AdamantiteBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.crit = 48;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(0, 0, 0, 20);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.AdamantiteBullet>();
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddIngredient(ItemID.AdamantiteBar)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}