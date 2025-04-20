namespace BulletExpress.Weapons.Ranged.Launcher
{
	public class AdamantiteAmmoLauncher : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
            
			AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ItemID.RocketLauncher;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.damage = 45;
            Item.crit = 8;
            Item.knockBack = 5;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.value = 50000;
            Item.rare = 4;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Meowmere;
            Item.scale = 1f;
            Item.shootSpeed = 7.5f;

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
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.AdamantiteBar, 12)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}