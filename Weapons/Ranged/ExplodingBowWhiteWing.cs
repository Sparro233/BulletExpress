namespace BulletExpress.Weapons.Ranged
{
	public class ExplodingBowWhiteWing : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>
            {
                {40, 793},
                {3103, 793}
            });
        }
        
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item5;
            Item.damage = 100;
            Item.crit = -72;
            Item.knockBack = 9;
            Item.useTime = 64;
            Item.useAnimation = 64;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = 4;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = 1;
            Item.shootSpeed = 20f;

            Item.width = 16;
            Item.height = 16;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1f, 0f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<Projectiles.Ranged.ExplodingBowWhiteWing>(), damage, knockback, player.whoAmI);
            Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.InkSilverBar>(), 14)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}