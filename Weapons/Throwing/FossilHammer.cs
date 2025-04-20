namespace BulletExpress.Weapons.Throwing
{
	public class FossilHammer : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
		{
            Item.DamageType = DamageClass.Melee;
			Item.useStyle = 1;
			Item.UseSound = SoundID.Item1;
            Item.damage = 11;
            Item.knockBack = 5.5f;
            Item.useTime = 19;
            Item.useAnimation = 28;
            Item.value = Item.sellPrice(0, 0, 40, 0);
            Item.rare = 1;

            Item.autoReuse = true;
                        
            Item.hammer = 55;
            
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