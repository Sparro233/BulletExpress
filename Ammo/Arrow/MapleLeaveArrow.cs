namespace BulletExpress.Ammo.Arrow
{
    public class MapleLeaveArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.crit = -48;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 0, 25);
            Item.rare = -11;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.MapleLeaveArrow>();
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(300)
            .AddIngredient(2766)
            .AddTile(TileID.Autohammer)
            .Register();
        }
    }
}
