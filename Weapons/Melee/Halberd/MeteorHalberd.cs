namespace BulletExpress.Weapons.Melee.Halberd
{
	public class MeteorHalberd : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item1;
            Item.damage = 55;
            Item.crit = 8;
            Item.knockBack = 11;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.value = 9500;
            Item.rare = 1;
            
            Item.channel = true;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Halberd.MeteorHalberd>();
            Item.shootSpeed = 0.9f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
		{
		    CreateRecipe()
            .AddIngredient(117, 12)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}