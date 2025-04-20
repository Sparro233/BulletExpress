namespace BulletExpress.Weapons.Energy
{
	public class LightHeartPiercingBow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Energy";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item102;
            Item.damage = 3;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.reuseDelay = 10;
            Item.value = 12000;
            Item.rare = 1;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = 1;
            Item.shootSpeed = 16f;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity, 932, damage * 3, knockback, player.whoAmI);
            }
            else
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity, 932, damage, knockback, player.whoAmI);

                const int Pro = 2;

                for (int i = 0; i < Pro; i++)
                {
                    Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(12));
                    Projectile.NewProjectile(player.GetSource_FromThis(), position, v, type, damage, knockback, player.whoAmI);
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.LightCrystal>(), 7)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}
