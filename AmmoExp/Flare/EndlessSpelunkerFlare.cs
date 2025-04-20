namespace BulletExpress.AmmoExp.Flare
{
    public class EndlessSpelunkerFlare : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Flare;
            Item.shoot = ProjectileID.SpelunkerFlare;
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.SpelunkerFlare, 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}