namespace BulletExpress.IDB.Potions
{
    public class SuperLifeSlagPotion : ModItem, ILocalizedModType
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

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 30;

            Item.autoReuse = false;
            Item.useTurn = true;
            Item.consumable = true;

            Item.buffType = (ModContent.BuffType<IDA.Buffs.Potion.SuperLifeSlagPotion>());
            Item.buffTime = 25000;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(9)
            .AddIngredient(3458, 2)
            .AddIngredient(ItemID.LesserHealingPotion, 2)
            .AddIngredient(ModContent.ItemType<LifeSlagPotion>(), 2)
            .AddIngredient(ModContent.ItemType<IDB.Materials.RefinedSaltBottle>(), 2)
            .AddTile(13)
            .Register();
        }
    }
}