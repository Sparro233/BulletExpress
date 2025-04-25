namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessNanoBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 15;
            Item.knockBack = 3.6f;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.NanoBullet;
            Item.shootSpeed = 4.6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.NanoBullet, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}