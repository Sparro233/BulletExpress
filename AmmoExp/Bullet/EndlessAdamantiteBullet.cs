namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessAdamantiteBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.crit = 48;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.AdamantiteBullet>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.AdamantiteBullet>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}