namespace BulletExpress.Weapons.Magic
{
    public class FinaleChord : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Magic";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Magic;
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 800;
            Item.knockBack = -255;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.value = 500000;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Magic.FinaleChord>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.VoltageBar>(), 12)
            .AddIngredient(ModContent.ItemType<IDB.Materials.StormBar>(), 50)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}