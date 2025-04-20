namespace BulletExpress.Weapons.Throwing
{
	public class MagicAxe : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
            Item.damage = 44;
            Item.crit = -32;
            Item.knockBack = 3;
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.value = Item.sellPrice(0, 3, 20, 0);
            Item.rare = 4;
			
            Item.autoReuse = true;
                        
            Item.hammer = 80;
            Item.axe = 20;
            
            Item.width = 16;
            Item.height = 16;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.MagicCrystal>(), 3)
            .AddRecipeGroup("AnyWood", 2)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}