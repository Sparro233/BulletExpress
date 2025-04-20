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
            //˪��
            player.buffImmune[BuffID.Frostburn] = true;
            //�䶳
            player.buffImmune[BuffID.Chilled] = true;
            //����
            player.buffImmune[BuffID.Frozen] = true;
            //ȼ��
            player.buffImmune[BuffID.Burning] = true;
            //�Ż�
            player.buffImmune[BuffID.OnFire] = true;
        }
    }
}