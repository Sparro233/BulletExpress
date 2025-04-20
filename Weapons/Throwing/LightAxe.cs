namespace BulletExpress.Weapons.Throwing
{
	public class LightAxe : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
            Item.damage = 12;
            Item.crit = -32;
            Item.knockBack = 3;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.value = Item.sellPrice(0, 2, 90, 0);
			Item.rare = 1;
			
            Item.autoReuse = true;
            
            Item.hammer = 40;
            Item.axe = 15;
            
            Item.width = 16;
            Item.height = 16;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.LightCrystal>(), 3)
            .AddRecipeGroup("AnyWood", 2)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}