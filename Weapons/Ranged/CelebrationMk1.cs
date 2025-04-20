namespace BulletExpress.Weapons.Ranged
{
	public class CelebrationMk1 : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item156;
            Item.damage = 50;
            Item.knockBack = 10;
            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.reuseDelay = 6;
            Item.value = 1;
            Item.rare = 10;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Rocket;
            Item.shoot = ProjectileID.Meowmere;
            Item.shootSpeed = 24f;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(50, 100);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, 0f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 velocity2 = velocity.RotatedByRandom(MathHelper.ToRadians(50)) * Main.rand.Next(15, 30) / 24;
            Vector2 velocity3 = velocity.RotatedByRandom(MathHelper.ToRadians(50)) * Main.rand.Next(15, 30) / 24;
            Vector2 velocity4 = velocity.RotatedByRandom(MathHelper.ToRadians(50)) * Main.rand.Next(15, 30) / 24;
            Vector2 velocity5 = velocity.RotatedByRandom(MathHelper.ToRadians(50)) * Main.rand.Next(15, 30) / 24;
            Vector2 velocity6 = velocity.RotatedByRandom(MathHelper.ToRadians(50)) * Main.rand.Next(15, 30) / 24;
            Vector2 velocity7 = velocity.RotatedByRandom(MathHelper.ToRadians(50)) * Main.rand.Next(15, 30) / 24;
            Vector2 velocity8 = velocity.RotatedByRandom(MathHelper.ToRadians(50)) * Main.rand.Next(15, 30) / 24;
            Vector2 velocity9 = velocity.RotatedByRandom(MathHelper.ToRadians(50)) * Main.rand.Next(15, 30) / 24;
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity2, 37, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity3, 516, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity4, 773, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity5, 906, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity6, 29, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity7, 470, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity8, 637, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity9, 28, damage, knockback, player.whoAmI);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.IllegalGunParts)
            .AddIngredient(ItemID.Bomb, 99)
            .Register();
        }
    }
}