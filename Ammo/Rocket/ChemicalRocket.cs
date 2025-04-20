namespace BulletExpress.Ammo.Rocket
{
    public class ChemicalRocket : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.ChemicalRocket>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.ChemicalRocket>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.ChemicalRocket>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.ChemicalRocket>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.ChemicalRocket>());
        }

        public override void SetDefaults()
        {
            Item.damage = 75;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 0, 5, 0);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Rocket.ChemicalRocket>();
            Item.shootSpeed = 1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(400)
            .AddIngredient(ModContent.ItemType<RocketZ>(), 400)
            .AddIngredient(ItemID.VialofVenom)
            .AddIngredient(ItemID.Bottle)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}