namespace  BulletExpress.AmmoExp.Bullet
{
    public class EndlessPartyBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 10;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.PartyBullet;
            Item.shootSpeed = 5.1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PartyBullet, 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}