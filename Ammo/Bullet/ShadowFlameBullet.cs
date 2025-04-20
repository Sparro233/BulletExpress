namespace BulletExpress.Ammo.Bullet
{
    public class ShadowFlameBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 4;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = 1;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.ShadowFlameBullet>();
            Item.shootSpeed = 4f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(300)
            .AddIngredient(ItemID.MusketBall, 300)
            .AddIngredient(ItemID.TatteredCloth)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}