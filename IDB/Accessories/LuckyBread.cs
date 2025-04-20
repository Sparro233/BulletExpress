namespace BulletExpress.IDB.Accessories
{
    public class LuckyBread : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.defense = 2;
            Item.value = Item.sellPrice(0, 0, 40, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            //生命再生
            player.lifeRegen += 2;
            //生命上限
            player.statLifeMax2 += 20;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.RefinedSugarBottle>(), 7)
            .AddIngredient(ModContent.ItemType<Materials.Flour>(), 7)
            .AddIngredient(ModContent.ItemType<Materials.SlimeCream>(), 7)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}