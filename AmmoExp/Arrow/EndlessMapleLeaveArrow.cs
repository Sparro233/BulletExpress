namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessMapleLeaveArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = -48;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 12, 0, 0);
            Item.rare = 3;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.MapleLeaveArrow>();
            Item.shootSpeed = 2f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.MapleLeaveArrow>(), 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}