namespace BulletExpress.Weapons.Ranged.Ter
{
    public class LemonJuiceBox : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.damage = 5;
            Item.knockBack = 1;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 2;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 8f;
            Item.scale = 1f;

            Item.width = 16;
            Item.height = 16;
        }
        
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return !Main.rand.NextBool(20, 100);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, 3f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 4, 0, position + offset, 0, 0))
            {
                position += offset;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(9));
            Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Coral, 7)
            .AddIngredient(2625, 7)
            .AddIngredient(2626, 7)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}