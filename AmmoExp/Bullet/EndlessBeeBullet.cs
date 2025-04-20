namespace BulletExpress.AmmoExp.Bullet
{
    public class EndlessBeeBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.knockBack = 0.25f;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.BeeArrow;
            Item.shootSpeed = 5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.BeeBullet>(), 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}