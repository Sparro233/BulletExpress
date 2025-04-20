namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class SleepingCrown : ModItem, ILocalizedModType
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
            Item.defense = 2;
            Item.value = Item.sellPrice(0, 0, 30, 0);
            Item.rare = 1;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<ZifPlayer>().AnkhCharmBless = true;

            player.statLifeMax2 += 20;
            player.lifeRegenCount += 2;
    }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SleepingPajamas> () && legs.type == ModContent.ItemType<SleepingShoes>();
        }

        public override void UpdateArmorSet(Player player) 
        {
            player.setBonus = "Immune magic disease\nSuction Heart Range Increases\nLife regeneration + 10\n免疫魔力病\n红心吸取范围增加\n生命回复+10";
            //免疫魔力病debuff
            player.buffImmune[BuffID.ManaSickness] = true;
            player.lifeMagnet = true;
            player.lifeRegenCount += 10;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.LightBar>(), 5)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
