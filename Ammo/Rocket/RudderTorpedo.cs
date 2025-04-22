namespace BulletExpress.Ammo.Rocket
{
    public class RudderTorpedo : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Torpedo.FlyingTorpedo>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Torpedo.FlyingTorpedo>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Torpedo.RudderMine>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Torpedo.RudderMine>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ModContent.ProjectileType<AmmoPro.Rocket.Torpedo.FlyingTorpedo>());
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 25;
            Item.knockBack = 8;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = 120;
            Item.rare = -11;

            Item.autoReuse = false;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Rocket.Torpedo.RudderMine>();
            Item.shootSpeed = 6f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(400)
            .AddIngredient(ItemID.LunarBar)
            .AddIngredient(ItemID.ChlorophyteBar)
            .AddIngredient(ItemID.HellstoneBar)
            .AddRecipeGroup("AnyEvilBar")
            .AddTile(TileID.Autohammer)
            .Register();
        }
    }
}
