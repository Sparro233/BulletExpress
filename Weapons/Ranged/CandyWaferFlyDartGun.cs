namespace BulletExpress.Weapons.Ranged
{
	public class CandyWaferFlyDartGun : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item98;
            Item.damage = 200;
            Item.knockBack = 0;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.value = 7810;
            Item.rare = 2;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = false;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Dart;
            Item.scale = 1f;
            Item.shoot = 1;
            Item.shootSpeed = 18f;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                Item.useAmmo = AmmoID.Dart;
                Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.PotionDart>();

            }
            else
            {
                Item.useAmmo = 0;
                Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.PotionDart>();
            }
            return true;
        }

        public override void HoldItem(Player player)
        {
            player.scope = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4.5f, 0.5f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 16, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CandyWaferDartGun>())
            .AddIngredient(ModContent.ItemType<IDB.Materials.SteelTube>())
            .AddIngredient(ModContent.ItemType<IDB.Materials.Flour>(), 12)
            .AddTile(TileID.Autohammer)
            .Register();
        }
    }
}