namespace BulletExpress.Weapons.Throwing.Protocol
{
	public class ChlorophyllProtocol : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = new SoundStyle($"{nameof(BulletExpress)}/IDB/Ogg/b010EnhanceDefenseTrees")
            {
                Volume = 1f,
                PitchVariance = 0.6f,
                MaxInstances = 3,
            };
            Item.damage = 60;
            Item.useTime = 30;
			Item.useAnimation = 30;
            Item.rare = 7;

            Item.autoReuse = true;
            //锁定攻击速度
            Item.attackSpeedOnlyAffectsWeaponAnimation = true;
            //使用武器时锁定玩家方向
            Item.ChangePlayerDirectionOnShoot = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Throwing.ChlorophyllProtocolA>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 goal = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceiling = goal.Y;
			if (ceiling > player.Center.Y - 200f)
			{
                ceiling = player.Center.Y - 200f;
			}
			for (int i = 0; i < 3; i++)
			{
				position = player.Center - new Vector2(Main.rand.NextFloat(400) * player.direction, 600f);
				position.Y -= 100 * i;
				Vector2 direction = goal - position;

				if (direction.Y < 0f)
				{
                    direction.Y *= -1f;
				}
				if (direction.Y < 40f)
				{
                    direction.Y = 40f;
				}

                direction.Normalize();
                direction *= velocity.Length();
                direction.Y += Main.rand.Next(-40, 40) * 0.02f;
				Projectile.NewProjectile(source, position, direction, type, damage * 2, knockback, player.whoAmI, 0f, ceiling);
			}

			return false;
		}

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(1225, 18)
            .AddIngredient(547, 1)
            .AddIngredient(548, 1)
            .AddIngredient(549, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}
