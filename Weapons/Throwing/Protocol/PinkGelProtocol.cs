namespace BulletExpress.Weapons.Throwing.Protocol
{
	public class PinkGelProtocol : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = new SoundStyle($"{nameof(BulletExpress)}/IDB/Ogg/b010EnhanceDefenseTrees")
            {
                Volume = 1f,
                PitchVariance = 0.2f,
                MaxInstances = 3,
            };
            Item.damage = 15;
            Item.useTime = 30;
			Item.useAnimation = 30;

            Item.autoReuse = true;

            Item.shoot = 517;
            Item.shootSpeed = 12f;

            Item.width = 16;
            Item.height = 16;
        }
        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 goal = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceiling = goal.Y;
            if (ceiling > player.Center.Y + 100f)
            {
                ceiling = player.Center.Y + 100;
            }
            for (int i = 0; i < 3; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(200) * player.direction, 600f);
                position.Y -= 100 * i;
                Vector2 direction = goal - position;

                if (direction.Y < 0f)
                {
                    direction.Y *= -1f;
                }
                if (direction.Y < 10f)
                {
                    direction.Y = 10f;
                }

                direction.Normalize();
                direction *= velocity.Length();
                direction.Y += Main.rand.Next(-10, 10) * 0.01f;
                Projectile.NewProjectile(source, position, direction, type, damage * 2, knockback, player.whoAmI, 0f, ceiling);
            }

            return false;
        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup("AnyIronBar", 10)
            .AddIngredient(3111, 10)
            .AddIngredient(170, 10)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
