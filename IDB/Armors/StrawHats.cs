namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class StrawHats : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";
        public override void SetStaticDefaults()
        {
            //阻止帽子覆盖头发
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
            //高帽子
            ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = false;
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 50, 0);

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateEquip(Player player)
        {
            DamageClass d = ModContent.GetInstance<BulletExpress.HortiDamage>();
            player.GetDamage(d) += 0.12f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<StrawBeetle>() && legs.type == ModContent.ItemType<StrawSkirt>();
        }

        public override void UpdateArmorSet(Player player) 
        {
            player.setBonus = "Endurance+10%\n耐力+10%";
            player.endurance += 0.1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(1727, 12)
            .Register();
        }
    }
}
