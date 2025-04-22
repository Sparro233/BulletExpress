namespace BulletExpress.Weapons.Ranged
{
	public class CandyWaferRifle : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.damage = 26;
            Item.knockBack = 3;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.value = 780000;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 8f;

            Item.width = 16;
            Item.height = 16;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, 5f);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.RefinedSugarBottle>(), 7)
            .AddIngredient(ModContent.ItemType<IDB.Materials.SlimeCream>(), 7)
            .AddIngredient(ModContent.ItemType<IDB.Materials.Flour>(), 7)
            .AddTile<IDA.Tiles.ElegantBlackOven>()
            .Register();
        }
    }
}