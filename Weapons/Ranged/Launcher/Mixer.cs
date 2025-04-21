namespace BulletExpress.Weapons.Ranged.Launcher
{
    public class Mixer : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;

            AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ItemID.GrenadeLauncher;

            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>
            {
                {ItemID.RocketIII, ProjectileID.Meowmere}
            });
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.damage = 30;
            Item.knockBack = 2.25f;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.value = 280;
            Item.rare = 1;

            Item.noMelee = true;

            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Meowmere;
            Item.scale = 1.1f;
            Item.shootSpeed = 6.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, 1f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 8, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<Projectiles.Ranged.RibBarrier>(), damage * 3, knockback, player.whoAmI);

            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(4)) * Main.rand.Next(15, 30) / 30;
            Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(1257, 4)
            .AddRecipeGroup("AnyWood", 2)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}
