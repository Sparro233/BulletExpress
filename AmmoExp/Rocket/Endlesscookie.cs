namespace BulletExpress.AmmoExp.Rocket
{
    public class EndlessCookie : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "AmmoExp.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            //曲奇
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.Cookie>());
            //奶油曲奇
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.CreamCookie> ());
            //枫树曲奇
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.MapleCookie> ());
            //炉渣饼干
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.SlagCookie>());
            //多彩饼干: ColorfulCookie
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.CreamCookie>());
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 7;
            Item.knockBack = 1;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = Item.sellPrice(0, 32, 0, 0);
            Item.rare = 2;

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Rocket.Cookie.SlagCookie>();
            Item.shootSpeed = 3f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Ammo.Rocket.Cookie>(), 3996)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}