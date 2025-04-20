namespace BulletExpress.Weapons.Horti
{
    public class InkGlassSword : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Horti";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 80;
            Item.knockBack = 4;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.value = 10000;
            Item.rare = 8;

            Item.autoReuse = true;
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;

            Item.scale = 1.2f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.InkGlassSword>();
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
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.InkGlassSword>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.Tear>();
                return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Horti.Tear>()] <= 8;
            }
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse != 2)
            {
                const int NumPro = 2;
                for (int i = 0; i < NumPro; i++)
                {
                    Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(3));
                    v *= 1f - Main.rand.NextFloat(0.08f);
                    Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
                }
            }
            else
            {
                const int NumPro = 3;
                for (int i = 0; i < NumPro; i++)
                {
                    Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(12));
                    Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
                }
            }
            return false;
        }
    }
}