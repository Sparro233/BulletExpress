namespace BulletExpress.Weapons.Ranged.Launcher
{
    public class NewYearLauncher : ModItem, ILocalizedModType
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
            Item.damage = 2;
            Item.crit = -48;
            Item.knockBack = 25;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.value = 25;

            Item.noMelee = true;

            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Meowmere;
            Item.shootSpeed = 12f;

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

            if (Main.rand.NextBool(5))
            {
                type = ModContent.ProjectileType<AmmoPro.Rocket.GoldIngot>();
                damage *= 2;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.StoneBlock, 2)
            .AddRecipeGroup("AnyWood", 2)
            .AddIngredient(ItemID.ClayBlock, 2)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}