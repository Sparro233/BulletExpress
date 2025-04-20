namespace BulletExpress.Weapons.Melee.Halberd
{
	public class SolarHalberd : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item109;
            Item.damage = 250;
            Item.crit = 12;
            Item.knockBack = 15;
            Item.useTime = 24;
            Item.useAnimation = 24;
			Item.value = 250000;
            Item.rare = 10;
            
            Item.channel = true;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Halberd.Collapse>();
            Item.shootSpeed = 1.1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
		{
		    CreateRecipe()
            .AddIngredient(3458, 12)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}