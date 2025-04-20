namespace BulletExpress.Ammo.Bullet
{
    public class EarlBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 14;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 0, 0, 25);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.EarlBullet>(); 
            Item.shootSpeed = 4.8f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(ItemID.EmptyBullet, 150)
            .AddIngredient(1508)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}