namespace BulletExpress.Weapons.Summon
{
	public class SpectreWhip : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Summon";
        public override bool MeleePrefix()
        {
            return true;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Summon;
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item152;
            Item.damage = 110;
            Item.knockBack = 10;
            Item.useTime = 32;
            Item.useAnimation = 32;
			Item.value = 28000;
            Item.rare = 8;

            Item.channel = true;
            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            
            Item.scale = 1f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Summon.BirchRhythm>();
            Item.shootSpeed = 4f;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3261, 7)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}