namespace BulletExpress.Weapons.Throwing
{
	public class LightAPickaxe : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
            Item.damage = 32;
            Item.crit = -32;
            Item.knockBack = 3;
            Item.useTime = 1;
            Item.useAnimation = 8;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = -12;
			
            Item.autoReuse = true;
            
            Item.pick = 65;
            Item.axe = 15;
            
            Item.width = 16;
            Item.height = 16;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3090)
            .AddIngredient(2341)
            .AddIngredient(2342)
            .AddIngredient(ModContent.ItemType<IDB.Materials.LightBar>(), 3)
            .AddRecipeGroup("AnyWood", 2)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}