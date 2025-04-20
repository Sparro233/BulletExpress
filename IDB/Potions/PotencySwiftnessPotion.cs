namespace BulletExpress.IDB.Potions
{
    public class PotencySwiftnessPotion : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Potions";
        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 30;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 1;

            Item.useStyle = 9;
            Item.UseSound = SoundID.Item3;
            Item.useTime = 17;
            Item.useAnimation = 17;

            Item.autoReuse = false;
            Item.useTurn = true;
            Item.consumable = true;

            Item.buffType = (ModContent.BuffType<IDA.Buffs.Potion.PotencySwiftnessPotion>());
            Item.buffTime = 50000;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(9)
            .AddIngredient(ItemID.BottledWater)
            .AddIngredient(290)
            .AddIngredient(ModContent.ItemType<IDB.Materials.StrayCotton>())
            .AddIngredient(183)
            .AddTile(13)
            .Register();
        }
    }
}