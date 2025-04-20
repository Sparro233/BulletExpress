namespace BulletExpress.Weapons.Ranged.Ter
{
    public class Violin : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item40;
            Item.damage = 38;
            Item.knockBack = 4;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 5;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 6f;
            Item.scale = 1f;

            Item.width = 16;
            Item.height = 16;
        }
        
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(40, 100);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 5f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 8, 0, position + offset, 2, 0))
            {
                position += offset;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(4));
            Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
            Projectile.NewProjectileDirect(source, position, v, ModContent.ProjectileType<AmmoPro.Bullet.HolyShelterBullet>(), damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HallowedBar, 12)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}