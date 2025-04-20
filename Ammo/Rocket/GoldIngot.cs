namespace BulletExpress.Ammo.Rocket
{
    public class GoldIngot : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.GoldIngot>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.GoldIngot>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.GoldIngot>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.GoldIngot>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.GoldIngot>());
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 5;
            Item.crit = 16;
            Item.knockBack = 0.25f;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = Item.sellPrice(0, 0, 50, 0);

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Rocket.GoldIngot>();
            Item.shootSpeed = 12f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
            .AddIngredient(1725)
            .AddRecipeGroup("AnyWood")
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}