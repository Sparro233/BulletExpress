namespace BulletExpress.Ammo.Bullet
{
    public class MythrilBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 6;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(0, 0, 0, 15);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.MythrilBullet>();
            Item.shootSpeed = 4f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(ItemID.MythrilBar)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}