namespace BulletExpress.AmmoExp.Snowball
{
    public class SnowballCourierBox : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 16;
            Item.knockBack = 5.75f;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 3;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Snowball;
            Item.shoot = ProjectileID.SnowBallFriendly;
            Item.shootSpeed = 14f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Snowball, 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}