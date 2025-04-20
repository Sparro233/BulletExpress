namespace BulletExpress.IDB.Materials
{
    public class LightPowder : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(8, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;

            /*ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;*/
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 0, 30);
            Item.rare = 1;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 25;

            ItemID.Sets.BossBag[Type] = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(32)
            .AddIngredient(ItemID.FallenStar, 1)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}