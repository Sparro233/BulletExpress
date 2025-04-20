namespace BulletExpress.IDB.Potions
{
    public class SuperNutrientPotion : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Potions";
        public override void SetDefaults()
        {
            Item.useStyle = 9;
            Item.UseSound = SoundID.Item3;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = 1;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 30;

            Item.autoReuse = false;
            Item.useTurn = true;
            Item.consumable = true;

            Item.potion = true;
            Item.healLife = 80;
            Item.buffType = (ModContent.BuffType<IDA.Buffs.Potion.SuperNutrientPotion>());
            Item.buffTime = 600;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(6)
            .AddIngredient(3458, 2)
            .AddIngredient(28, 2)
            .AddIngredient(ModContent.ItemType<NutrientPotion>(), 2)
            .AddIngredient(ModContent.ItemType<IDB.Materials.RefinedSugarBottle>(), 2)
            .AddIngredient(ModContent.ItemType<IDB.Materials.RefinedSaltBottle>(), 2)
            .AddIngredient(317, 2)
            .AddIngredient(314, 2)
            .AddTile(13)
            .Register();
        }
    }
}