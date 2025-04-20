namespace BulletExpress.AmmoExp.Bullet
{
    public class EndlessEarlBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 16;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.EarlBullet>();
            Item.shootSpeed = 5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.EarlBullet>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}