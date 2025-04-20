namespace BulletExpress.Weapons.Ranged.Launcher
{
	public class SeaBlueLauncher : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.IsSpecialist[Type] = true;
			AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ItemID.SnowmanCannon;
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>
            {{
                ItemID.RocketIII, ProjectileID.Meowmere
            }});
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.damage = 12;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.value = Item.sellPrice(0, 5, 50, 0);
            Item.rare = 2;

            Item.noMelee = true;

            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Meowmere;
            Item.shootSpeed = 8f;
            Item.scale = 1.1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 1f);
        }
        
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 4, 0, position + offset, 0, 0))
            {
                position += offset;
            }
        }
    }
}