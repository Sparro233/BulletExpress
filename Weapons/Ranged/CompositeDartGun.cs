namespace BulletExpress.Weapons.Ranged
{
	public class CompositeDartGun : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item98;
            Item.damage = 20;
            Item.knockBack = 1;
            Item.useTime = 18;
            Item.useAnimation = 18;
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

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.DemoniteBar, 4)
            .AddIngredient(ModContent.ItemType<IDB.Materials.SteelTube>())
            .AddRecipeGroup("AnyEbonwood", 12)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}