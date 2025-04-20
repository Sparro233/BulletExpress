namespace BulletExpress.Ammo.Rocket
{
    public class BlackBolt : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Rocket";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ProjectileID.BlackBolt);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ProjectileID.BlackBolt);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ProjectileID.BlackBolt);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ProjectileID.BlackBolt);
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ProjectileID.BlackBolt);
        }

        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.crit = 16;
            Item.knockBack = 4.5f;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ProjectileID.BlackBolt;
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(500)
            .AddIngredient(ItemID.StoneBlock, 500)
            .AddIngredient(ItemID.ExplosivePowder, 50)
            .AddIngredient(ItemID.SoulofNight, 10)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}