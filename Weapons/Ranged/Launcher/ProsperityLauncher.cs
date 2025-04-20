namespace BulletExpress.Weapons.Ranged.Launcher
{
	public class ProsperityLauncher : ModItem, ILocalizedModType
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
            Item.UseSound = SoundID.Item11;
            Item.damage = 14;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.value = 1000;
            Item.rare = 3;

            Item.noMelee = true;

            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Stynger;
            Item.shootSpeed = 6f;
            Item.scale = 1.1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 0f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 8, 0, position + offset, 0, 0))
            {
                position += offset;
            }
            if (Main.rand.NextBool(6))
            {
                type = ProjectileID.Stynger;
                velocity /= 2;
                damage *= 2;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Stinger)
            .AddIngredient(ItemID.JungleSpores, 3)
            .AddIngredient(ItemID.Vine, 6)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}