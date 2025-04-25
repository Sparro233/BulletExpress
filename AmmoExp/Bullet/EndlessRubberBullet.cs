namespace BulletExpress.AmmoExp.Bullet
{
    public class EndlessRubberBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.crit = 16;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.RubberBullet>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Bullet.RubberBullet>(), 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}