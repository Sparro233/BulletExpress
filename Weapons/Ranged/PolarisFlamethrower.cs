namespace BulletExpress.Weapons.Ranged
{
    public class PolarisFlamethrower : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.damage = 50;
            Item.knockBack = 2;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.rare = 3;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Gel;
            Item.scale = 1f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.Fireball>();
            Item.shootSpeed = 16f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0f, 2f);
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Ranged.Fireball>()] <= 7;    
            return true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumPro = 2;

            for (int i = 0; i < NumPro; i++)
            {
                Vector2 v = velocity.RotatedByRandom(MathHelper.ToRadians(0));
                Projectile.NewProjectileDirect(source, position, v, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(1184, 10)
            .AddIngredient(ModContent.ItemType<IDB.Materials.InkGoldBar>(), 6)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}