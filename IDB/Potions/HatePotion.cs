namespace BulletExpress.IDB.Potions
{
    public class HatePotion : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Potions";
        public override void SetDefaults()
        {
            Item.useStyle = 9;
            Item.UseSound = SoundID.Item3;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = Item.sellPrice(0, 0, 8, 0);
            Item.rare = 1;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 30;

            Item.autoReuse = false;
            Item.useTurn = true;
            Item.consumable = true;

            Item.healLife = -20;
            Item.buffType = (ModContent.BuffType<IDA.Buffs.Potion.HatePotion>());
            Item.buffTime = 25000;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(9)
            .AddIngredient(126, 1)
            .AddRecipeGroup("AnyWormTooth", 1)
            .AddIngredient(316, 1)
            .AddIngredient(318, 1)
            .AddTile(13)
            .Register();
        }
    }
}