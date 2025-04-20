namespace BulletExpress.Weapons.Ranged
{
    public class ChlorophyteSubmachineGun : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>
            {
                {97, ModContent.ProjectileType<Projectiles.Ranged.ChlorophyteEnergy>()},
                {3104, ModContent.ProjectileType<Projectiles.Ranged.ChlorophyteEnergy>()}
            });
        }
        
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item31;
            Item.damage = 42;
            Item.crit = 8;
            Item.knockBack = 4;
            Item.useTime = 5;
            Item.useAnimation = 15;
            Item.reuseDelay = 20;
            Item.value = Item.sellPrice(0, 3, 20, 0);
            Item.rare = 7;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Bullet;
            Item.scale = 1.1f;
            Item.shoot = 1;
            Item.shootSpeed = 6f;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(40, 100);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 5f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 8, 0, position + offset, 2, 0))
            {
                position += offset;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(2));
            Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
            Projectile.NewProjectileDirect(source, position, v * 2, ModContent.ProjectileType<Projectiles.Ranged.LifeLight>(), damage / 2, knockback, player.whoAmI);

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.ChlorophyteBar, 12)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}