namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    public class SleepingShoes : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";
        public override void SetDefaults()
        {
            Item.defense = 2;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 1;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 80;
            player.lifeRegenCount += 8;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.LightBar>(), 5)
            .AddIngredient(225, 5)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
