namespace BulletExpress.AmmoExp.Bullet
{
    public class EndlessHighVelocityNanoBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 13;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.HighVelocityNanoBullet>();
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.HighVelocityNanoBullet>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}