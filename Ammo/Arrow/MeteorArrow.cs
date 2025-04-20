namespace BulletExpress.Ammo.Arrow
{
    public class MeteorArrow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Arrow";
        public override void SetDefaults()
        { 
            Item.damage = 10;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = 1;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Arrow.MeteorArrow>();
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(70)
            .AddIngredient(ItemID.MeteoriteBar)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}