namespace BulletExpress.IDB.Materials.Courier
{
    public class AshesCourier : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Materials";
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.SandgunAmmoProjectileData[Type] = new(ModContent.ProjectileType<Projectiles.Throwing.AshesProtocol>(), 10);
        }

        public override void SetDefaults()
        {
            Item.ResearchUnlockCount = 1;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = 3;
            Item.ResearchUnlockCount = 3;

            Item.useStyle = 1;
            Item.useTime = 10;
            Item.useAnimation = 14;

            Item.autoReuse = true;

            Item.notAmmo = true;
            Item.ammo = AmmoID.Sand;

            //ItemID.Sets.BossBag[Type] = true;
            //ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;
            //Item.expert = true;

            //Item.consumable = true;
            //Item.createTile =
            //ModContent.TileType<IDA.Tiles.ChlorophyllExpress>();
            Item.DefaultToPlaceableTile(ModContent.TileType<IDA.Tiles.AshesCourier>());
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
            itemLoot.Add(ItemDropRule.Common(116, 4, 6, 60));
            itemLoot.Add(ItemDropRule.Common(173, 4, 6, 60));
            itemLoot.Add(ItemDropRule.Common(174, 4, 6, 60));
            //itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<NPCs.Boss>()));
        }
        
		//自定义工作站.AddTile<IDA.Tiles.???>()
    }
}