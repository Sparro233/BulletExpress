namespace BulletExpress.Weapons.Ranged
{
	public class ManganeseBow : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetStaticDefaults()
        {
            AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int>
            {
                {40, ModContent.ProjectileType<AmmoPro.Arrow.TinArrow>()},
                {3103, ModContent.ProjectileType<AmmoPro.Arrow.TinArrow>()}
            });
        }
        
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item5;
            Item.damage = 4;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.value = 50;

            Item.autoReuse = true;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = 1;
            Item.shootSpeed = 5.5f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.ManganeseBar>(), 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
