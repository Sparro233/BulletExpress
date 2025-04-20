namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessHighVelocityBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 11;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.BulletHighVelocity;
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HighVelocityBullet, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}