namespace BulletExpress.Weapons.Ranged.Launcher
{
	public class SakuraPowderEmitter : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            
			AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ItemID.RocketLauncher;

            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>
            {{ ItemID.RocketIII, ProjectileID.Meowmere }});
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.damage = 35;
            Item.crit = 8;
            Item.knockBack = 5;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.value = 114514;
            Item.rare = 5;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Meowmere;
            Item.shootSpeed = 7f;
            Item.scale = 1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-20f, 4f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 10, 0, position + offset, 2, 0))
            {
                position += offset;
            }

            if (Main.rand.NextBool(4))
            {
                type = ModContent.ProjectileType<AmmoPro.Rocket.Sakura.Sakura>();
                damage *= 2;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.OrichalcumBar, 12)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}