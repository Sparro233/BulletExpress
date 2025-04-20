namespace BulletExpress.IDB.Materials.Courier
{
    public class ChlorophyllCourier : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;

            ItemID.Sets.SandgunAmmoProjectileData[Type] = new(ModContent.ProjectileType<Projectiles.Throwing.ChlorophyllProtocol>(), 50);
        }

        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 1;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = 7;
            Item.ResearchUnlockCount = 3;

            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;

            Item.autoReuse = true;

            Item.notAmmo = true;
            Item.ammo = AmmoID.Sand;

            Item.DefaultToPlaceableTile(ModContent.TileType<IDA.Tiles.ChlorophyllCourier>());
            Item.placeStyle = 0;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(1328, 10, 1, 1));
            itemLoot.Add(ItemDropRule.Common(947, 2, 10, 100));
        }
    }
}