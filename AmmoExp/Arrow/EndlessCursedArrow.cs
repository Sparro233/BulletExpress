namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessCursedArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 17;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = 2;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.CursedArrow;
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.CursedArrow, 3996)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}