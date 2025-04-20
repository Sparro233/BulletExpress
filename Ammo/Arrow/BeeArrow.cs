namespace BulletExpress.Ammo.Arrow
{
    public class BeeArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 9;
            Item.knockBack = 3;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.BeeArrow;
            Item.shootSpeed = 2f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(ItemID.WoodenArrow, 150)
            .AddIngredient(ItemID.BeeWax)
            .AddIngredient(ItemID.Hive)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}