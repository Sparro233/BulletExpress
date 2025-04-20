namespace BulletExpress.IDB.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    public class LightWing : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.rare = 3;
            Item.value = Item.sellPrice(0, 3, 0, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }
         
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //免疫坠落
            player.noFallDmg = true;
            base.UpdateAccessory(player, hideVisual);
            if (hideVisual)
            {
                player.wingTimeMax = 40;
            }
            else 
            {
                player.wingTimeMax = 40;
            }
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            constantAscend = 0.1f;
            maxAscentMultiplier = 1.5f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            //翅膀水平移动数据
            speed = 7f;
            acceleration = 1f;
        }

        public override void UpdateArmorSet(Player player)
        {
            //伤害减免
            player.endurance += 0.05f;
            player.armorEffectDrawShadow = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.LightBar>(), 4)
            .AddIngredient(ModContent.ItemType<Materials.LightPowder>(), 20)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
        


 