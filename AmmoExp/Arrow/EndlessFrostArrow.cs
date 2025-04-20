namespace BulletExpress.AmmoExp.Arrow
{
    public class EndlessFrostArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 8;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.FrostArrow;
            Item.shootSpeed = 4.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Arrow.FrostArrow>(), 3996)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}