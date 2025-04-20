namespace BulletExpress.Weapons.Melee
{
	public class FossilShortsword : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {   
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item1;
            Item.damage = 14;
            Item.knockBack = 3;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.value = Item.sellPrice(0, 0, 25, 0);
            Item.rare = 1;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.FossilShortsword>();
            Item.shootSpeed = 4.2f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FossilOre, 6)
            .AddTile(TileID.Anvils)
            .Register();
        }
	}
}