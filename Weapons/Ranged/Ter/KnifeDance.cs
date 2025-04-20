namespace BulletExpress.Weapons.Ranged.Ter
{
	public class KnifeDance : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item36;
            Item.damage = 65;
            Item.knockBack = 12;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.reuseDelay = 10;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 8;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 8f;
            Item.scale = 1.1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(39, 1200);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, 0f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 12, 0, position + offset, 2, 0))
            {
                position += offset;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<Projectiles.Ranged.CurseFlamingBlade>(), damage, knockback, player.whoAmI);
            //如果主射弹为，则更改为
            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<AmmoPro.Bullet.ShadowFlameBullet>();
            }
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

            for (int i = 0; i < 3; i++)
            {
                Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(24));
                v *= 1f - Main.rand.NextFloat(0.4f);
                Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
            }
            
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y + 200f)
            {
                ceilingLimit = player.Center.Y + 200f;
            }
            for (int i = 0; i < 3; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(1200) * player.direction, 400f);
                position.Y -= 100 * i;
                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-20, 20) * 0.02f;
                Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Shadow>())
            .AddIngredient(547, 20)
            .AddIngredient(548, 20)
            .AddIngredient(549, 20)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}