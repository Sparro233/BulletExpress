namespace BulletExpress.Weapons.Throwing
{
	public class GiliconAPickaxe : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item71;
            Item.damage = 255;
            Item.crit = -255;
            Item.knockBack = 3;
            Item.useTime = 1;
            Item.useAnimation = 8;
            Item.rare = -1;
			
            Item.autoReuse = true;

            Item.pick = 1000;
            Item.axe = 200;
            
            Item.width = 16;
            Item.height = 16;
        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.GiliconBar>(), 3)
            .AddRecipeGroup("AnyWood", 2)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}