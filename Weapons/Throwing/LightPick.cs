namespace BulletExpress.Weapons.Throwing
{
	public class LightPick : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
            Item.damage = 10;
            Item.crit = -32;
            Item.knockBack = 3;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 1;
			
            Item.autoReuse = true;
            
            Item.pick = 50;
            
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