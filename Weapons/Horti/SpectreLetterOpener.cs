namespace BulletExpress.Weapons.Horti
{
    public class SpectreLetterOpener : ModItem, ILocalizedModType
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
            Item.damage = 45;
            Item.knockBack = 4;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.value = 20000;
            Item.rare = 8;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.SpectreLetterOpener>();
            Item.shootSpeed = 12f;

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
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.SpectreLetterOpener>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.SpectreTear>();
                return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Horti.SpectreTear>()] == 0;
            }
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumPro = 3;

            for (int i = 0; i < NumPro; i++)
            {
                Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(6));

                v *= 1f - Main.rand.NextFloat(0.3f);

                Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3261, 7)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}