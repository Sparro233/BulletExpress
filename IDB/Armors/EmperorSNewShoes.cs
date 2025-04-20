namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    public class EmperorSNewShoes : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";
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
