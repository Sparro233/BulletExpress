 namespace BulletExpress.AmmoExp.Bullet
{
    public class EndlessBookStaffShotBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.crit = 16;
            Item.knockBack = 0.5f;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = 712;
            Item.shootSpeed = 8f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.BookStaffShotBullet>(), 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}