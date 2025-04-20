namespace BulletExpress.Ammo.Arrow
{
    public class PulseBolt : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 22;
            Item.value = Item.sellPrice(0, 0, 0, 15);
            Item.rare = 1;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = 357;
            Item.shootSpeed = 1f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(300)
            .AddIngredient(1346)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}