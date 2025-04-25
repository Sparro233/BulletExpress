namespace BulletExpress.AmmoExp.Bullet
{
    public class EndlessNailBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 30;
            Item.knockBack = 3f;
            Item.value = 39960;
            Item.rare = 10;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.NailFriendly;
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Nail, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}