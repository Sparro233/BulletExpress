namespace BulletExpress.Weapons.Horti
{
    public class SolarScissors : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Horti";
        public override bool MeleePrefix()
        {
            return true;
        }

        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 70;
            Item.knockBack = 6;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.value = 200000;
            Item.rare = 10;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.SolarScissors>();
            Item.shootSpeed = 18f;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.SolarScissors>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.SunTear>();
                return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Horti.SunTear>()] == 0;
            }
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(6));
                v *= 1f - Main.rand.NextFloat(0.3f);
                Projectile.NewProjectileDirect(source, position, v, type, damage * 6, knockback, player.whoAmI);
            }
            else
            {
                Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(6));
                v *= 1f - Main.rand.NextFloat(0.3f);
                Projectile.NewProjectileDirect(source, position, v, ModContent.ProjectileType<Projectiles.Horti.SolarScissors>(), damage, knockback, player.whoAmI);

                Vector2 v2 = velocity.RotatedByRandom(MathHelper.ToRadians(6));
                v2 *= 1f - Main.rand.NextFloat(0.3f);
                Projectile.NewProjectileDirect(source, position, v2, ModContent.ProjectileType<Projectiles.Horti.SolarScissorsI>(), damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3458, 7)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}