namespace BulletExpress.Weapons.Ranged
{
	public class CandyWaferDartGun : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item98;
            Item.damage = 25;
            Item.knockBack = 0;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.value = 7810;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = false;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Dart;
            Item.scale = 1f;
            Item.shoot = 1;
            Item.shootSpeed = 14f;

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

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-1f, 2.5f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 12, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.RefinedSugarBottle>(), 7)
            .AddIngredient(ModContent.ItemType<IDB.Materials.SlimeCream>(), 7)
            .AddIngredient(ModContent.ItemType<IDB.Materials.Flour>(), 7)
            .AddTile<IDA.Tiles.ElegantBlackOven>()
            .Register();
        }
    }
}