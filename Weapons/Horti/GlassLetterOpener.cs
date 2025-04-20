namespace BulletExpress.Weapons.Horti
{
    public class GlassLetterOpener : ModItem, ILocalizedModType
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
            Item.damage = 8;
            Item.knockBack = 1.25f;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.value = 600;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Horti.GlassLetterOpener>();
            Item.shootSpeed = 10f;
            
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
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.GlassLetterOpener>();
            }
            else
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.GlassTear>();
                return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Horti.GlassTear>()] == 0;
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(170, 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}