namespace BulletExpress.IDB.Accessories
{
    public class LifeChip : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.defense = 4;
            Item.rare = 1;
            Item.value = Item.sellPrice(0, 0, 50, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //无跌伤
            player.noFallDmg = true;
            //生命再生
            player.lifeRegen += 3;
            //移动速度
            player.moveSpeed += 0.08f;
            //击退(通用)
            player.GetKnockback(DamageClass.Generic) += 4f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(999)
            .AddRecipeGroup("AnyBar", 5)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}