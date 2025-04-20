namespace BulletExpress.IDB.Accessories
{
    public class RedstoneOrnament : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {            
            Item.defense = 4;
            Item.rare = 10;

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //穿透+
            player.GetArmorPenetration(DamageClass.Generic) += 10;
            //基础伤害+
            player.GetDamage(DamageClass.Generic).Base += 10;
            //额外伤害+
            player.GetDamage(DamageClass.Generic).Flat += 10;
            //伤害
            player.GetDamage(DamageClass.Generic) += 0.1f;
            //暴击
            player.GetCritChance(DamageClass.Generic) += 10f;
            //击退
            player.GetKnockback(DamageClass.Generic) += 2f;
            //攻击速度
            player.GetAttackSpeed(DamageClass.Generic) += 0.1f;
            //召唤上限
            player.maxMinions += 1;
            //固定生命再生
            player.lifeRegenCount += 1;
            //生命上限
            player.statLifeMax2 += 100;
            //魔力上限
            player.statManaMax2 += 100;
            //移动速度
            player.moveSpeed -= 0.1f;
            //伤害减免
            player.endurance -= 0.1f;
            base.UpdateAccessory(player, hideVisual);
            if (hideVisual)
            {
                //锁定飞行时间(如果你不设置时间或负数会导致无法飞行，如果你设置为过小数会导致一些奇奇怪怪的后果，但你可能需要它)
                player.wingTime = 10000;
                player.wingTimeMax = 10000;
                player.wingTime = player.wingTimeMax;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<KryptonCrystal>())
            .AddIngredient(ModContent.ItemType<Catball>())
            .AddIngredient(ModContent.ItemType<NatureChip>())
            .AddIngredient(ModContent.ItemType<MagicChip>())
            .AddIngredient(ModContent.ItemType<DestroyChip>())
            .AddIngredient(ModContent.ItemType<TechnologyChip>())
            .AddIngredient(ModContent.ItemType<LifeChip>())
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}