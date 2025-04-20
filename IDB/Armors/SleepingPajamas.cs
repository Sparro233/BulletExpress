namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class SleepingPajamas : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";
        public override void SetDefaults()
        {
            Item.defense = 6;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateEquip(Player player) 
        {
            player.statLifeMax2 += 50;
            player.lifeRegenCount += 5;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.LightBar>(), 10)
            .AddIngredient(225, 10)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}