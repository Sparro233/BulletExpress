namespace BulletExpress.Ammo.Bullet
{
    public class BookStaffShotBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.crit = 16;
            Item.knockBack = 0.5f;
            Item.value = Item.sellPrice(0, 0, 0, 5);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.BookStaffShot;
            Item.shootSpeed = 8f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddIngredient(149)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}