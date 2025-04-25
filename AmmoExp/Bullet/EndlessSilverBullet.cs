namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessSilverBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 9;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.SilverBullet;
            Item.shootSpeed = 4.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.SilverBullet, 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}