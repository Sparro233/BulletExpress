namespace BulletExpress.IDB.Accessories
{
    public class MagicChip : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.rare = 1;
            Item.value = Item.sellPrice(0, 2, 0, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            //魔法穿透
            player.GetArmorPenetration(DamageClass.Magic) += 8;
            //魔力上限
            player.statManaMax2 += 20;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(177)
            .AddRecipeGroup("AnyBar", 10)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
