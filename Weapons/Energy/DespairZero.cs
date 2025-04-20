namespace BulletExpress.Weapons.Energy
{
	public class DespairZero : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Energy";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
			AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ItemID.RocketLauncher;
			AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>
			{
                {ItemID.RocketIII, ProjectileID.Meowmere}
            });
        }

        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item87;
            Item.mana = 8;
            Item.damage = 100;
            Item.crit = 26;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.rare = 10;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.MagicMissile;
            //Item.shoot = 723;
            Item.shootSpeed = 12f;
            Item.scale = 1.1f;

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
                Item.UseSound = SoundID.Item87;
                Item.mana = 6;

                Item.useAmmo = AmmoID.Rocket;
                Item.shoot = ProjectileID.MagicMissile;
            }
            else
            {
                Item.UseSound = SoundID.Item11;
                Item.mana = 0;

                Item.useAmmo = AmmoID.Bullet;
                Item.shoot = ProjectileID.MagicMissile;
            }
            return true;
        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {  
            //如果主射弹为，则更改为
            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<AmmoPro.Bullet.HorizonBullet>();
            }
            if (player.altFunctionUse == 2)
            {
                //选中主射弹
                int ammo = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
                //如果主射弹属性不足，则补足
                if (Main.projectile[ammo].extraUpdates < 2)
                {
                    Main.projectile[ammo].extraUpdates = 2;
                }
                if (Main.projectile[ammo].penetrate <= 2 && Main.projectile[ammo].penetrate != -1)
                {
                    Main.projectile[ammo].penetrate = 2;
                    Main.projectile[ammo].localNPCHitCooldown = 20;
                    Main.projectile[ammo].usesLocalNPCImmunity = true;
                }
                ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;

                Projectile.NewProjectileDirect(source, position, velocity * 0.9f, type, damage, knockback, player.whoAmI);
                
                Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                float ceilingLimit = target.Y;
                if (ceilingLimit > player.Center.Y + 200f)
                {
                    ceilingLimit = player.Center.Y + 200;
                }
                for (int i = 0; i < 3; i++)
                {
                    position = player.Center - new Vector2(Main.rand.NextFloat(500) * player.direction, 600f);
                    position.Y -= 100 * i;
                    Vector2 heading = target - position;

                    if (heading.Y < 0f)
                    {
                        heading.Y *= -1f;
                    }

                    if (heading.Y < 10f)
                    {
                        heading.Y = 10f;
                    }

                    heading.Normalize();
                    heading *= velocity.Length();
                    heading.Y += Main.rand.Next(-10, 10) * 0.02f;
                    Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
                }

                return false;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(0));

                    v *= 1f - Main.rand.NextFloat(0.6f);

                    Projectile.NewProjectileDirect(source, position, v, ModContent.ProjectileType<Projectiles.Energy.Extinguish>(), damage, knockback, player.whoAmI);

                    type = 0;
                }
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-13f, 4f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 20, 0, position + offset, 2, 0))
            {
                position += offset;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.IllegalGunParts, 5)
            .AddIngredient(ItemID.LunarBar, 5)
            .AddIngredient(3456, 5)
            .AddIngredient(3457, 5)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}