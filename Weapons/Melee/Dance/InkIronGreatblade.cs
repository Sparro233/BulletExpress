namespace BulletExpress.Weapons.Melee.Dance
{
	public class InkIronGreatblade : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 30;
            Item.knockBack = 4f;
            Item.useTime = 26;
            Item.useAnimation = 42;
            Item.value = 12000;
            Item.rare = 2;

            Item.autoReuse = true;

            Item.scale = 1.2f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Dance.RevengeSwordDance>();
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
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
            .AddIngredient(ModContent.ItemType<IDB.Materials.InkIronBar>(), 14)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}