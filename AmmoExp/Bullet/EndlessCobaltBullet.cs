namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessCobaltBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.CobaltBullet>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.CobaltBullet>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}