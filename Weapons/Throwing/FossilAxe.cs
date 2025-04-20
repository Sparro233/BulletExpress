namespace BulletExpress.Weapons.Throwing
{
	public class FossilAxe : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
            Item.damage = 9;
            Item.knockBack = 4.5f;
            Item.useTime = 12;
            Item.useAnimation = 26;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = 1;
			
            Item.autoReuse = true;
            
            Item.axe = 11;
            
            Item.width = 16;
            Item.height = 16;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FossilOre, 8)
            .AddRecipeGroup("AnyWood",3)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}