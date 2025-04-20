namespace BulletExpress.Weapons.Ranged.Launcher
{
	public class TinAmmoLauncher : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;

            AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ItemID.GrenadeLauncher;

            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>
            {{ ItemID.RocketIII, ProjectileID.Meowmere }});
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item61;
            Item.damage = 5;
            Item.crit = 4;
            Item.knockBack = 1.25f;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.value = Item.sellPrice(0, 0, 10, 0);

            Item.noMelee = true;

            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Meowmere;
            Item.shootSpeed = 5.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0f, 6f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 8, 0, position + offset, 0, 0))
            {
                position += offset;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.TinBar, 4)
            .AddRecipeGroup("AnyWood", 2)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}