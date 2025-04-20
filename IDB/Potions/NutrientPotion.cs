namespace BulletExpress.IDB.Potions
{
    public class NutrientPotion : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Potions";
        public override void SetDefaults()
        {
            Item.useStyle = 9;
            Item.UseSound = SoundID.Item3;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;

            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 30;

            Item.autoReuse = false;
            Item.useTurn = true;
            Item.consumable = true;

            Item.potion = true;
            Item.healLife = 20;
            Item.buffType = (ModContent.BuffType<IDA.Buffs.Potion.NutrientPotion>());
            Item.buffTime = 600;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(3)
            .AddIngredient(ItemID.BottledWater)
            .AddIngredient(ModContent.ItemType<IDB.Materials.RefinedSugarBottle>())
            .AddIngredient(ModContent.ItemType<IDB.Materials.RefinedSaltBottle>())
            .AddIngredient(ItemID.PinkGel)
            .AddTile(13)
            .Register();
        }
    }
}