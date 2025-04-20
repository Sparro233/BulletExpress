namespace BulletExpress.Ammo.Arrow
{
    public class ShadowFlameArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 8;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = 1;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ProjectileID.ShadowFlameArrow;
            Item.shootSpeed = 2.5f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(300)
            .AddIngredient(ItemID.WoodenArrow, 300)
            .AddIngredient(ItemID.TatteredCloth)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}