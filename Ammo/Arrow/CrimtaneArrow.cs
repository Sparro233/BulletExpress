namespace BulletExpress.Ammo.Arrow
{
    public class CrimtaneArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 9;
            Item.knockBack = 4.75f;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = 1;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.CrimtaneArrow>();
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
            .AddIngredient(ItemID.CrimtaneBar)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}