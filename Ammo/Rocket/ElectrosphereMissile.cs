namespace BulletExpress.Ammo.Rocket
{
    public class ElectrosphereMissile : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ProjectileID.ElectrosphereMissile);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ProjectileID.ElectrosphereMissile);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ProjectileID.ElectrosphereMissile);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ProjectileID.ElectrosphereMissile);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ProjectileID.ElectrosphereMissile);
        }

        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 30, 0);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ProjectileID.ElectrosphereMissile;
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(300)
            .AddIngredient(ModContent.ItemType<RocketZ>(), 300)
            .AddIngredient(2860)
            .AddTile(247)
            .Register();
        }
    }
}