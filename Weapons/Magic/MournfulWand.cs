namespace BulletExpress.Weapons.Magic
{
	public class MournfulWand : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Magic";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Magic;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item15;
            Item.mana = 14;
            Item.damage = 30;
            Item.knockBack = 2;
            Item.useTime = 9;
            Item.useAnimation = 15;
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.rare = 3;

            Item.staff[Type] = true;
            Item.autoReuse = true;
            Item.noMelee = true;

            Item.shoot = 640;
            Item.shootSpeed = 18f;
            
            Item.width = 16;
            Item.height = 16;
        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.MythrilBar,4)
            .AddIngredient(ModContent.ItemType<IDB.Materials.InkCopperBar>(), 6)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}