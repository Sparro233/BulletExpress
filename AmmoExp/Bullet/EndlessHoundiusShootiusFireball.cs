namespace BulletExpress.AmmoExp.Bullet
{
    public class EndlessHoundiusShootiusFireball : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 72;
            Item.knockBack = 6f;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.HoundiusShootiusFireball;
            Item.shootSpeed = 5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.HoundiusShootiusFireball>(), 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}