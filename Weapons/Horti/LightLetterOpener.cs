namespace BulletExpress.Weapons.Horti
{
    public class LightLetterOpener : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Horti";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 24;
            Item.knockBack = 1.25f;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.value = 12000;
            Item.rare = 1;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.LightLetterOpener>();
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
                Item.UseSound = SoundID.Item1;
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.LightLetterOpener>();
            }
            else
            {
                Item.UseSound = SoundID.Item60;
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.LightCutting>();
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.LightBar>(), 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}