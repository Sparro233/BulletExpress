namespace BulletExpress.Ammo.Flare
{
    public class StormFlashbang : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Item.ammo = AmmoID.Flare;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Flare.StormFlashbang>();
            Item.shootSpeed = 10f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
            .AddIngredient(ModContent.ItemType<ThunderZapperBullet>(), 200)
            .AddIngredient(530)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}