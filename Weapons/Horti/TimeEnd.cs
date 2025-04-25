namespace BulletExpress.Weapons.Horti
{
    public class TimeEnd : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Horti";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item169;
            Item.damage = 360;
            Item.knockBack = 2;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.value = 200000;
            Item.rare = 10;

            //Item.channel = true;
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;


            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.TimeEnd>();
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
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.TimeEnd>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.END>();
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.IllegalGunParts, 5)
            .AddIngredient(ItemID.LunarBar, 5)
            .AddIngredient(3458, 5)
            .AddIngredient(3459, 5)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}