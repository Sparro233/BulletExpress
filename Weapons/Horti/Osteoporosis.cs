namespace BulletExpress.Weapons.Horti
{
	public class Osteoporosis : ModItem, ILocalizedModType
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
            Item.knockBack = 1.5f;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.value = 10000;
            Item.rare = 2;

            ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            Item.autoReuse = true;

            Item.shootSpeed = 12f;
            Item.scale = 1.1f;
            
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
                Item.shoot = 304;
                return player.ownedProjectileCounts[304] == 0;
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup("AnyIronBar", 7)
            .AddIngredient(ItemID.Bone, 7)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}