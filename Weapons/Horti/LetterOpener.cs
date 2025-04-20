namespace BulletExpress.Weapons.Horti
{
    public class LetterOpener : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Horti";
        public override bool MeleePrefix()
        {
            return true;
        }

        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 12;
            Item.knockBack = 2;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.value = 950;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.LetterOpener>();
            Item.shootSpeed = 8f;
            
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
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.LetterOpener>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.Tear>();
                return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Horti.Tear>()] == 0;
            }
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(6));
            Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup("AnyIronBar", 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}