namespace BulletExpress.Weapons.Ranged
{
	public class EmuCatsSubmachineGun : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.damage = 75;
            Item.crit = 4;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.value = 62000;
            Item.rare = 8;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 8f;
            
            Item.width = 16;
            Item.height = 16;
        }
        
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(40, 100);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, 3f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 4, 0, position + offset, 2, 0))
            {
                position += offset;
            }

            if (Main.rand.NextBool(5))
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity, ModContent.ProjectileType<Projectiles.Horti.KristiaTear>(), damage, knockback * 0, player.whoAmI);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(7));
            Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}