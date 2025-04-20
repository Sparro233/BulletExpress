namespace BulletExpress.Ammo.Rocket
{
    public class BetsyRocket : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ProjectileID.ApprenticeStaffT3Shot);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ProjectileID.ApprenticeStaffT3Shot);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ProjectileID.ApprenticeStaffT3Shot);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ProjectileID.ApprenticeStaffT3Shot);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ProjectileID.ApprenticeStaffT3Shot);
        }

        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 0, 15, 0);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ProjectileID.ApprenticeStaffT3Shot;
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(300)
            .AddIngredient(ModContent.ItemType<RocketZ>(), 300)
            .AddIngredient(ItemID.DefenderMedal)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}