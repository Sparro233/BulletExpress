namespace BulletExpress.AmmoExp.CandyCorn
{
    public class CandyCornCourierBox : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 27;
            Item.knockBack = 3;
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 3;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.CandyCorn;
            Item.shoot = ModContent.ProjectileType<AmmoPro.CandyCorn.BoomCandyCorn>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ShroomiteBar)
            .AddIngredient(ItemID.CandyCorn, 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}