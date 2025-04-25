namespace BulletExpress.Weapons.Horti
{
    public class StormLetterOpener : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Horti";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 80;
            Item.knockBack = 1.5f;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.value = 80000;
            Item.rare = 10;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.StormLetterOpener>();
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
                Item.UseSound = SoundID.Item1;
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.StormLetterOpener>();
            }
            else
            {
                Item.UseSound = SoundID.Item60;
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.StormCutting>();
            }
            return true;
        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.StormBar>(), 7)
            .AddIngredient(ModContent.ItemType<MagicLetterOpener>())
            .AddIngredient(ModContent.ItemType<LightLetterOpener>())
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}