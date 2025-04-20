namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessIchorArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 16;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = 278;
            Item.shootSpeed = 4.25f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.IchorArrow, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}