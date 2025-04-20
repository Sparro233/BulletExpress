namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class EmperorSNewClothes : ModItem, ILocalizedModType
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

        public override void UpdateEquip(Player player)
        {
            //Ëª¶³
            player.buffImmune[BuffID.Frostburn] = true;
            //Àä¶³
            player.buffImmune[BuffID.Chilled] = true;
            //±ù¶³
            player.buffImmune[BuffID.Frozen] = true;
            //È¼ÉÕ
            player.buffImmune[BuffID.Burning] = true;
            //×Å»ð
            player.buffImmune[BuffID.OnFire] = true;
        }
    }
}