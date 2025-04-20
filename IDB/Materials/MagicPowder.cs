namespace BulletExpress.IDB.Materials
{
    public class MagicPowder : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetStaticDefaults()
        {
        //    Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
        //    ItemID.Sets.AnimatesAsSoul[Item.type] = true;

        //    ItemID.Sets.ItemIconPulse[Item.type] = true; // 该物品在玩家的物品栏中时会跳动
        //    ItemID.Sets.ItemNoGravity[Item.type] = true; // 让掉落物漂浮，不配合动画会报错
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 0, 50);
            Item.rare = 4;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 25;

            ItemID.Sets.BossBag[Type] = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(32)
            .AddIngredient(501, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}