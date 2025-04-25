namespace BulletExpress.IDB.Potions
{
    public class WildPotion : ModItem, ILocalizedModType
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

            Item.healLife = -20;
            Item.buffType = 148;
            Item.buffTime = 50000;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(9)
            .AddIngredient(126)
            .AddRecipeGroup("AnyWormTooth")
            .AddIngredient(316)
            .AddIngredient(318)
            .AddTile(13)
            .Register();
        }
    }
}