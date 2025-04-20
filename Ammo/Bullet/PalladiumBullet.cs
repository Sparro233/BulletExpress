namespace BulletExpress.Ammo.Bullet
{
    public class PalladiumBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.PalladiumBullet>();
            Item.shootSpeed = 1f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
            .AddIngredient(ItemID.PalladiumBar)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}