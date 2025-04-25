namespace BulletExpress.Ammo.Bullet
{
    public class SpiderBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.knockBack = 1.25f;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.SpiderBullet>();
            Item.shootSpeed = 6f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(2607, 1)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}