namespace BulletExpress.Weapons.Throwing
{
	public class MagicAPickaxe : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;// 71
            Item.damage = 64;
            Item.crit = -64;
            Item.knockBack = 3;
            Item.useTime = 1;
            Item.useAnimation = 8;
            Item.value = Item.sellPrice(0, 15, 50, 0);
            Item.rare = -12;
			
            Item.autoReuse = true;
            
            Item.pick = 175;
            Item.axe = 30;
            
            Item.width = 16;
            Item.height = 16;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(4987)
            .AddIngredient(5337)
            .AddIngredient(5339)
            .AddIngredient(ModContent.ItemType<IDB.Materials.MagicBar>(), 3)
            .AddRecipeGroup("AnyWood", 2)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}