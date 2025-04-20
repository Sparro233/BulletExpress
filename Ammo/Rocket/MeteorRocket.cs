namespace BulletExpress.Ammo.Rocket
{
    public class MeteorRocket : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ProjectileID.Meteor1);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ProjectileID.Meteor1);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ProjectileID.Meteor1);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ProjectileID.Meteor1);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ProjectileID.Meteor1);
        }

        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.crit = 16;
            Item.value = Item.sellPrice(0, 0, 0, 30);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Meteor1;
            Item.shootSpeed = 0.4f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(ItemID.MeteoriteBar)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}