namespace BulletExpress.Weapons.Throwing
{
	public class ManganeseAxe : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
            Item.damage = 2;
            Item.knockBack = 5;
            Item.useTime = 20;
            Item.useAnimation = 30;
            Item.value = Item.sellPrice(0, 0, 10, 0);

            Item.autoReuse = true;
                        
            Item.axe = 6;
            
            Item.width = 16;
            Item.height = 16;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.ManganeseBar>(), 6)
            .AddRecipeGroup("AnyWood", 3)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}