namespace BulletExpress.IDB.Accessories
{
    public class DestroyChip : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.rare = 1;
            Item.value = Item.sellPrice(0, 4, 0, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            //穿透+
            player.GetArmorPenetration(DamageClass.Generic) += 1;
            //基础伤害+
            player.GetDamage(DamageClass.Generic).Base += 1;
            //额外伤害+
            player.GetDamage(DamageClass.Generic).Flat += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(178)
            .AddRecipeGroup("AnyBar", 30)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}