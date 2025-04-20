namespace BulletExpress.Weapons.Ranged
{
    public class LotusSeedsBurstOut : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>
            {
                {97, ModContent.ProjectileType<Projectiles.Ranged.LotusSeed>()},
                {3104, ModContent.ProjectileType<Projectiles.Ranged.LotusSeed>()}
            });
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.damage = 26;
            Item.knockBack = 2;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 4;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = false;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.LotusSeed>();
            Item.shootSpeed = 8f;
            Item.scale = 1.2f;

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
                Item.useTime = 8;
                Item.useAnimation = 8;

                Item.useAmmo = AmmoID.Bullet;
                Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.LotusSeed>();

            }
            else
            {
                Item.useTime = 16;
                Item.useAnimation = 16;

                Item.useAmmo = 0;
                Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.LotusSeedBoom>();
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 2f);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 8, 0, position + offset, 0, 0))
            {
                position += offset;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.OrichalcumBar, 4)
            .AddIngredient(ModContent.ItemType<IDB.Materials.InkCopperBar>(), 6)
            .AddIngredient(ModContent.ItemType<IDB.Materials.SteelTube>(), 6)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}