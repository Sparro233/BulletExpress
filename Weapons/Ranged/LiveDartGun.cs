namespace BulletExpress.Weapons.Ranged
{
	public class LiveDartGun : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item99;
            Item.damage = 30;
            Item.knockBack = 1;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.value = 7810;
            Item.rare = 1;

            Item.autoReuse = false;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Dart;
            Item.scale = 1.1f;
            Item.shoot = 1;
            Item.shootSpeed = 8f;

            Item.width = 16;
            Item.height = 16;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0f, 4f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 4, 0, position + offset, 2, 0))
            {
                position += offset;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectileDirect(source, position, velocity, ModContent.ProjectileType<Projectiles.Ranged.RibBarrier>(), damage * 3, knockback, player.whoAmI);

            Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.CrimtaneBar, 4)
            .AddIngredient(ModContent.ItemType<IDB.Materials.SteelTube>())
            .AddRecipeGroup("AnyEbonwood", 12)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}
