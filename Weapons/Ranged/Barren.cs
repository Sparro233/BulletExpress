namespace BulletExpress.Weapons.Ranged
{
	public class Barren : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item41;
            Item.damage = 24;
            Item.knockBack = 6;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = 2;

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
            return new Vector2(4f, 4f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3380, 7)
            .AddIngredient(999, 7)
            .AddIngredient(ItemID.AntlionMandible, 7)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}