namespace BulletExpress.Weapons.Horti
{
    public class MagicLetterOpener : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Horti";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 30;
            Item.knockBack = 2;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.value = 20000;
            Item.rare = 4;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.MagicLetterOpener>();
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
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.MagicLetterOpener>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.MagicTear>();
                return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Horti.MagicTear>()] <= 1;
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<BulletExpress.IDB.Materials.MagicBar>(), 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}