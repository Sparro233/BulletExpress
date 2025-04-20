namespace BulletExpress.Ammo.Rocket
{
    public class RocketZ : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            //火箭
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ProjectileID.RocketI);
            //雪人
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ProjectileID.RocketSnowmanI);
            //榴弹
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ProjectileID.GrenadeI);
            //地雷
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ProjectileID.ProximityMineI);
            //MK2
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ProjectileID.Celeb2Rocket);
        }

        public override void SetDefaults()
        {
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 20;
            Item.knockBack = 4;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.value = Item.sellPrice(0, 0, 0, 25);

            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ProjectileID.RocketI;
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddRecipeGroup("AnyBar")
            .AddIngredient(530)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}