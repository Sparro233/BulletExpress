namespace BulletExpress.Weapons.Horti
{
    public class GreetingCard : ModItem, ILocalizedModType
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
            Item.damage = 28;
            Item.knockBack = 2;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.value = 3800;
            Item.rare = 3;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.GreetingCard>();
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
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.GreetingCard>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.Greeting>();
                return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Horti.Greeting>()] == 0;
            }
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 1;

            for (int i = 0; i < NumProjectiles; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(6));
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(313, 120);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup("AnyIronBar", 7)
            .AddIngredient(175, 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}