namespace BulletExpress.IDB.Accessories
{
    public class KryptonCrystal : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.defense = 4;
            Item.rare = 0;
            Item.value = Item.sellPrice(0, 1, 0, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.noKnockback = false;
        }
    }
}