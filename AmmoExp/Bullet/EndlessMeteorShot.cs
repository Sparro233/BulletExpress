namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessMeteorShot : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 8;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.MeteorShot;
            Item.shootSpeed = 3f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MeteorShot, 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}