namespace BulletExpress.Weapons.Melee.Halberd
{
	public class LeadHalberd : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item1;
            Item.damage = 35;
            Item.crit = 8;
            Item.knockBack = 9;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.value = 100;

            Item.channel = true;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Halberd.LeadHalberd>();
            Item.shootSpeed = 0.8f;
            
            Item.width = 16;
            Item.height = 16;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
            .AddIngredient(ItemID.LeadBar, 12)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}