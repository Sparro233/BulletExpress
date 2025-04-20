namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class ManganeseHelmet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            SetBonusText = this.GetLocalization("SetBonus");
            //如果您的头部设备在绘制头发时应绘制头发，请使用以下方法之一
            //根本不画头部。由 Space Creature Mask 使用
            //ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
            //画头发，就像帽子遮住了顶部一样。由 Wizards Hat 使用
            //ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
            //正常绘制所有头发。用于 Mime Mask， Sunglasses
            //ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; 
            //ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.defense = 1;

            Item.width = 18;
            Item.height = 18;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ManganeseBreastplate>() && legs.type == ModContent.ItemType<ManganeseLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.GetDamage(DamageClass.Summon) += 0.4f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.ManganeseBar>(), 5)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
