namespace BulletExpress.Ammo.Rocket
{
    public class Cookie : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            //ÇúÆæ
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.Cookie>());
            //ÄÌÓÍÇúÆæ
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.CreamCookie> ());
            //·ãÊ÷ÇúÆæ
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.MapleCookie> ());
            //Â¯Ôü±ý¸É
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Cookie.SlagCookie>());
            //¶à²Ê±ý¸É: ColorfulCookie
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
            Item.value = Item.sellPrice(0, 0, 0, 80);

            Item.autoReuse = false;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Rocket.Cookie.SlagCookie>();
            Item.shootSpeed = 3f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
            .AddIngredient(ItemID.DemoniteBar)
            .AddRecipeGroup("AnyWood")
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}