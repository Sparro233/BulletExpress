namespace BulletExpress.IDB.Accessories
{
    public class NatureChip : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.defense = 2;
            Item.rare = 1;
            Item.value = Item.sellPrice(0, 0, 80, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noFallDmg = true;
            //ÕÙ»½ÉÏÏÞ
            player.maxMinions += 1;
            //»÷ÍË
            player.GetKnockback(DamageClass.Generic) += 2f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(179)
            .AddRecipeGroup("AnyBar", 15)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}