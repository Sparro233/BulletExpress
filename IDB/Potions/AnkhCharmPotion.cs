namespace BulletExpress.IDB.Potions
{
    public class AnkhCharmPotion : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Potions";
        public override void SetDefaults()
        {
            Item.useStyle = 9;
            Item.UseSound = SoundID.Item3;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = 1;

            Item.autoReuse = false;
            Item.useTurn = true;
            Item.consumable = true;
            
            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 30;

            Item.healLife = 20;
            Item.buffType = (ModContent.BuffType<IDA.Buffs.Bless.AnkhCharmBless>());
            Item.buffTime = 50000;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(9)
            .AddIngredient(ItemID.BottledWater)
            .AddIngredient(528)
            .AddIngredient(527)
            .AddIngredient(526)
            .AddTile(13)
            .Register();
        }
    }
}