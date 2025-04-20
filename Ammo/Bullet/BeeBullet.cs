namespace BulletExpress.Ammo.Bullet
{
    public class BeeBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 6;
            Item.knockBack = 0.25f;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.BeeArrow;
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(ItemID.MusketBall, 150)
            .AddIngredient(ItemID.BeeWax)
            .AddIngredient(ItemID.Hive)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}