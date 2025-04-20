namespace BulletExpress.Weapons.Horti
{
    public class Kristia : ModItem, ILocalizedModType
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
            Item.damage = 40;
            Item.knockBack = 3;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.value = 91000;
            Item.rare = 5;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.HeavenlyWing>();
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
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.HeavenlyWing>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.KristiaTear>();
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(1225, 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}