namespace BulletExpress.Ammo.Bullet
{
    public class RubberBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 8;
            Item.crit = 16;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = 0;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.RubberBullet>();
            Item.shootSpeed = 4f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddIngredient(ItemID.EmptyBullet, 200)
            .AddIngredient(ItemID.Gel)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}