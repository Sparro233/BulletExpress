namespace BulletExpress.Weapons.Ranged.Ter
{
	public class Shadow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item40;
            Item.damage = 55;
            Item.knockBack = 16;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.rare = 3;

            Item.autoReuse = false;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 12f;
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
            return new Vector2(-12f, 2f);
        }
        
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 20, 0, position + offset, 2, 0))
            {
                position += offset;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity, 974, damage, knockback, player.whoAmI);
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
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 2; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(200) * player.direction, 600f);
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
                heading.Y += Main.rand.Next(-40, 40) * 0.02f;
                Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
            }

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup("NibbledOrMAGIII")
            .AddIngredient(ModContent.ItemType<Glacier>())
            .AddIngredient(ModContent.ItemType<LemonJuiceBox>())
            .AddIngredient(219)
            .AddTile(TileID.DemonAltar)
            .Register();
        }
    }
}