namespace BulletExpress.IDB.Potions.Food
{
    public class MicroChocolate : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Potions.Food";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 5;
            Main.RegisterItemAnimation(Type, new DrawAnimationVertical(int.MaxValue, 3));
            ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
                new Color(249, 230, 136),
                new Color(152, 93, 95),
                new Color(174, 192, 192)
            };

            ItemID.Sets.IsFood[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.UseSound = SoundID.Item2;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = 800;
            Item.rare = 1;

            Item.maxStack = 9999;
            Item.ResearchUnlockCount = 30;

            Item.autoReuse = false;
            Item.useTurn = true;
            Item.consumable = true;

            Item.buffType = (ModContent.BuffType<IDA.Buffs.Food.ChineseFastFood>());
            Item.buffTime = 50000;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(9)
            .AddIngredient(ModContent.ItemType<IDB.Materials.RefinedSugarBottle>())
            .AddIngredient(ModContent.ItemType<IDB.Materials.MagicPowder>())
            .AddTile(13)
            .Register();
        }
    }
}