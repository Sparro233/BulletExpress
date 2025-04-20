namespace BulletExpress.Weapons.Throwing
{
	public class StormAPickaxe : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
            Item.damage = 128;
            Item.crit = -128;
            Item.knockBack = 3;
            Item.useTime = 1;
            Item.useAnimation = 8;
            Item.value = Item.sellPrice(0, 30, 0, 0);
            Item.rare = 10;
			
            Item.autoReuse = true;
            
            Item.pick = 210;
            Item.axe = 40;
            
            Item.width = 16;
            Item.height = 16;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.StormBar>(), 3)
            .AddRecipeGroup("AnyWood", 2)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}