namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessChlorophyteBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 9;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.ChlorophyteBullet;
            Item.shootSpeed = 5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ChlorophyteBullet, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}