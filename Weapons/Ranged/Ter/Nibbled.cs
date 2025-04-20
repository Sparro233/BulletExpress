namespace BulletExpress.Weapons.Ranged.Ter
{
	public class Nibbled : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item38;
            Item.damage = 16;
            Item.knockBack = 4;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = 1;

            Item.noMelee = true;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 8f;

            Item.width = 16;
            Item.height = 16;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 6f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 20f;

            if (Collision.CanHit(position, 8, 0, position + offset, 0, 0))
            {
                position += offset;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumPro = 3;
            for (int i = 0; i < NumPro; i++)
            {
                Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(3));
                v *= 1f - Main.rand.NextFloat(0.2f);
                Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
            }

            return false;
        }
        
        public override void AddRecipes()
		{
		    CreateRecipe()
            .AddIngredient(ItemID.DemoniteBar, 10)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}