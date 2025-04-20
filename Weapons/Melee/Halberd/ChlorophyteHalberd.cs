namespace BulletExpress.Weapons.Melee.Halberd
{
	public class ChlorophyteHalberd : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item1;
            Item.damage = 110;
            Item.knockBack = 12;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.value = 38440;
            Item.rare = 7;
            
            Item.channel = true;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Halberd.ChlorophyteHalberd>();
            Item.shootSpeed = 1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
		{
		    CreateRecipe()
            .AddIngredient(ItemID.ChlorophyteBar, 12)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}