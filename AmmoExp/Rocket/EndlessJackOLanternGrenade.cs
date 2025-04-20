namespace BulletExpress.AmmoExp.Rocket
{
    public class EndlessJackOLanternGrenade : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Rocket";
        public override void SetStaticDefaults()
        {
             AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, 312);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, 312);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, 312);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, 312);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, 312);
        }
        
        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 15;
            Item.knockBack = 12f;
            Item.useTime = 34;
            Item.useAnimation = 34;
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = 2;

            Item.noMelee = true;
            Item.noUseGraphic = true;
            
            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = 312;
            Item.shootSpeed = 8f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Rocket.JackOLanternGrenade>(), 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}