namespace BulletExpress.AmmoExp.Bullet
{
    public class EndlessMapleLeaveBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = -48;
            Item.knockBack = 2.25f;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.MapleLeaveBullet>();
            Item.shootSpeed = 8f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.MapleLeaveBullet>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}