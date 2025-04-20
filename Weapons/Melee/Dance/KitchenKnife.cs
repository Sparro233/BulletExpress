namespace BulletExpress.Weapons.Melee.Dance
{
	public class KitchenKnife : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 10;
            Item.knockBack = 2;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.value = 6400;

            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Dance.RevengeSwordDance>();
            Item.shootSpeed = 1.1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity, 364, damage, knockback, player.whoAmI);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item);
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI);
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.InkIronBar>(), 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}