namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class EmperorSNewCrown : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";
        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
            ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.defense = 999;
            Item.value = Item.sellPrice(9, 9, 9, 9);
            Item.rare = -13;

            Item.width = 16;
            Item.height = 16;
        }
    }
}
