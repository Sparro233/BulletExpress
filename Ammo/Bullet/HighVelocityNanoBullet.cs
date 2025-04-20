namespace BulletExpress.Ammo.Bullet
{
    public class HighVelocityNanoBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 13;
            Item.knockBack = 4;
            Item.value = 16;
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.HighVelocityNanoBullet>();
            Item.shootSpeed = 6f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddIngredient(ItemID.EmptyBullet, 200)
            .AddIngredient(1346)
            .AddIngredient(1344)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}