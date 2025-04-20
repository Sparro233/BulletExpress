namespace BulletExpress.Ammo.Rocket
{
    public class Waffle : ModItem
    {
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ProjectileID.Waffle);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ProjectileID.Waffle);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ProjectileID.Waffle);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ProjectileID.Waffle);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ProjectileID.Waffle);
        }
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 50;
            Item.crit = 4;
            Item.knockBack = 4.75f;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = Item.sellPrice(0, 0, 5, 0);

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Waffle;
            Item.shootSpeed = 12f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(1725)
            .AddIngredient(501)
            .AddIngredient(68)
            .AddRecipeGroup("AnyWood")
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}