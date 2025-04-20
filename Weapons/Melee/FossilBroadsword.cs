namespace BulletExpress.Weapons.Melee
{
	public class FossilBroadsword : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {   
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 17;
            Item.knockBack = 6.5f;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.value = Item.sellPrice(0, 15, 0, 0);
            Item.rare = 1;

            Item.autoReuse = true;

            Item.scale = 1.1f;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.FossilOre, 8)
            .AddTile(TileID.Anvils)
            .Register();
        }
	}
}