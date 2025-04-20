namespace BulletExpress.Ammo.Rocket
{
    public class MiniSharkronRocket : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 2));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;

            AmmoID.Sets.IsSpecialist[Type] = true;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.RocketLauncher].Add(Type, ModContent.ProjectileType<Projectiles.Geberic.MiniSharkron>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.SnowmanCannon].Add(Type, ModContent.ProjectileType<Projectiles.Geberic.MiniSharkron>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.GrenadeLauncher].Add(Type, ModContent.ProjectileType<Projectiles.Geberic.MiniSharkron>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.ProximityMineLauncher].Add(Type, ModContent.ProjectileType<Projectiles.Geberic.MiniSharkron>());
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches[ItemID.Celeb2].Add(Type, ModContent.ProjectileType<Projectiles.Geberic.MiniSharkron>());
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 16;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 50, 0);

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Rocket;
            Item.shoot = ModContent.ProjectileType<Projectiles.Geberic.MiniSharkron>();
            Item.shootSpeed = 10f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddIngredient(ModContent.ItemType<RocketZ>(), 200)
            .AddIngredient(2290)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}