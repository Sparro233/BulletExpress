namespace BulletExpress.IDB.Armors
{
	[AutoloadEquip(EquipType.Legs)]
	public class ManganeseLeggings : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";
        public override void SetDefaults() 
        {
			Item.defense = 1;

            Item.width = 18;
            Item.height = 18;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.ManganeseBar>(), 4)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
