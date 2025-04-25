namespace BulletExpress.AmmoExp.Bullet
{
    public class EndlessHorizonTearBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 50, 0, 0);
            Item.rare = -11;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.HorizonBullet>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.HorizonTearBullet>(), 9999)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}