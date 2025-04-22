namespace BulletExpress.IDB.Materials
{
    public class TangerineCoconut : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ModContent.ProjectileType<Projectiles.Ranged.Tangerine>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ModContent.ProjectileType<Projectiles.Ranged.Tangerine>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ModContent.ProjectileType<Projectiles.Ranged.Tangerine>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ModContent.ProjectileType<Projectiles.Ranged.Tangerine>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ModContent.ProjectileType<Projectiles.Ranged.Tangerine>());
        }

        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 1;
            Item.maxStack = 9999;
            Item.useTime = 10;
            Item.useAnimation = 14;
            Item.value = 500;

            Item.useStyle = 1;

            Item.maxStack = 9999;

            Item.autoReuse = true;
            Item.consumable = true;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;

            Item.consumable = true;
            Item.createTile = ModContent.TileType<IDA.Tiles.TangerineCoconut>();
            Item.placeStyle = 0;

            Item.width = 16;
            Item.height = 16;
        }
        public override void AddRecipes()
        {
            CreateRecipe(64)
            .AddIngredient(2504)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}