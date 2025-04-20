namespace BulletExpress.Ammo.Bullet
{
    public class HolyShelterBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.knockBack = 2.5f;
            Item.value = Item.sellPrice(0, 0, 0, 25);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.HolyShelterBullet>();
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddIngredient(1225)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}