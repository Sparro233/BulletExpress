namespace BulletExpress.IDB.Armors
{
	[AutoloadEquip(EquipType.Body)]
	public class ManganeseBreastplate : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";

        public static readonly int MaxManaIncrease = 20;
		public static readonly int MaxMinionIncrease = 2;

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxManaIncrease, MaxMinionIncrease);

		public override void SetDefaults() 
		{
			Item.defense = 1;

            Item.width = 18;
            Item.height = 18;
        }

		public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += MaxManaIncrease;
            player.maxMinions += MaxMinionIncrease; 
		}

		public override void AddRecipes() 
		{
			CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.ManganeseBar>(), 8)
            .AddTile(TileID.Anvils)
			.Register();
		}
	}
}
