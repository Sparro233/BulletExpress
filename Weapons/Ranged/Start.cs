namespace BulletExpress.Weapons.Ranged
{
	public class Start : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item41;
            Item.damage = 16;
            Item.knockBack = 1;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.value = 7810;
            Item.rare = 4;

            Item.autoReuse = false;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Flare;
            Item.shoot = 1;
            Item.shootSpeed = 2f;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int bullet = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, 0f);
            if (Main.projectile[bullet].extraUpdates < 4)
            {
                Main.projectile[bullet].extraUpdates = 4;
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(3f, 4f);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.SteelTube>())
            .AddIngredient(ItemID.IllegalGunParts)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}