namespace BulletExpress.Ammo.Rocket
{
    public class HuraCrepitan : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, 483);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, 483);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, 483);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, 483);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, 483);
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 10;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = 5;
            Item.value = Item.sellPrice(0, 0, 0, 50);

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = 483;
            Item.shootSpeed = 4f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddIngredient(ItemID.StoneBlock)
            .AddIngredient(ItemID.Stinger)
            .AddIngredient(ItemID.Acorn)
            .AddRecipeGroup("AnyWood")
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}