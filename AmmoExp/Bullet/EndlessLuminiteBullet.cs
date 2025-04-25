namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessLuminiteBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 20;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 50, 0, 0);
            Item.rare = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = 638;
            Item.shootSpeed = 2f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3567, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}