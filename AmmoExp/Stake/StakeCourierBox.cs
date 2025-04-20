namespace BulletExpress.AmmoExp.Stake
{
    public class StakeCourierBox : ModItem
    {
        public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item1;
            Item.damage = 50;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Stake;
            Item.shoot = ProjectileID.Stake;
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ShroomiteBar)
            .AddIngredient(ItemID.Stake, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}