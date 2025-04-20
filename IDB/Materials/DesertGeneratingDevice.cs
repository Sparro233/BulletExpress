namespace BulletExpress.IDB.Materials
{
    public class DesertGeneratingDevice : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;

            ItemID.Sets.SandgunAmmoProjectileData[Type] = new(ModContent.ProjectileType<Projectiles.Ranged.ArtificialDesert>(), 100);
        }

        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 1;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = 2;
            Item.ResearchUnlockCount = 3;

            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;

            Item.autoReuse = true;

            Item.notAmmo = true;
            Item.ammo = AmmoID.Sand;

            Item.DefaultToPlaceableTile(ModContent.TileType<IDA.Tiles.DesertGeneratingDevice>());
            Item.placeStyle = 0;

            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(999)
            .AddIngredient(607, 10)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}