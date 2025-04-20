namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessExplodingBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 10;
            Item.knockBack = 6.6f;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.ExplosiveBullet;
            Item.shootSpeed = 4.7f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ExplodingBullet, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}