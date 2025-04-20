namespace BulletExpress.Weapons.Throwing
{
	public class ManganesPick : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
            Item.damage = 2;
            Item.knockBack = 2;
            Item.useTime = 8;
            Item.useAnimation = 24;
            Item.value = Item.sellPrice(0, 0, 5, 0);

            Item.autoReuse = true;
            
            Item.pick = 20;
            
            Item.width = 16;
            Item.height = 16;
        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.ManganeseBar>(), 12)
            .AddRecipeGroup("AnyWood", 4)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}