namespace BulletExpress.Weapons.Horti
{
	public class LightMarkLetterOpener : ModItem, ILocalizedModType
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
            Item.damage = 20;
            Item.knockBack = 3.5f;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.value = 5000;
            Item.rare = 1;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shootSpeed = 20f;
            
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
                Item.shoot = ModContent.ProjectileType<Projectiles.Horti.LetterOpener>();
            }
            else
            {
                Item.shoot = 729;
                return player.ownedProjectileCounts[729] == 0;
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup("AnyIronBar", 7)
            .AddIngredient(ModContent.ItemType<IDB.Materials.LightCrystal>(), 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}