namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessVenomBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 15;
            Item.knockBack = 4.1f;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.VenomBullet;
            Item.shootSpeed = 5.3f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.VenomBullet, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}