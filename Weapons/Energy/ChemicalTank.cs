namespace BulletExpress.Weapons.Energy
{
	public class ChemicalTank : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Energy";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 168;
            Item.useTime = 80;
            Item.useAnimation = 80;
            Item.value = Item.sellPrice(0, 2, 20, 0);
            Item.rare = 8;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Energy.ChemicalTank>();
            Item.shootSpeed = 18f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3105)
            .AddIngredient(ModContent.ItemType<IDB.Materials.EncapsulatedGilicon>(), 10)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}