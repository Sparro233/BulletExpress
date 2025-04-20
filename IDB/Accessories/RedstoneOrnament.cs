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
            //��͸+
            player.GetArmorPenetration(DamageClass.Generic) += 10;
            //�����˺�+
            player.GetDamage(DamageClass.Generic).Base += 10;
            //�����˺�+
            player.GetDamage(DamageClass.Generic).Flat += 10;
            //�˺�
            player.GetDamage(DamageClass.Generic) += 0.1f;
            //����
            player.GetCritChance(DamageClass.Generic) += 10f;
            //����
            player.GetKnockback(DamageClass.Generic) += 2f;
            //�����ٶ�
            player.GetAttackSpeed(DamageClass.Generic) += 0.1f;
            //�ٻ�����
            player.maxMinions += 1;
            //�̶���������
            player.lifeRegenCount += 1;
            //��������
            player.statLifeMax2 += 100;
            //ħ������
            player.statManaMax2 += 100;
            //�ƶ��ٶ�
            player.moveSpeed -= 0.1f;
            //�˺�����
            player.endurance -= 0.1f;
            base.UpdateAccessory(player, hideVisual);
            if (hideVisual)
            {
                //��������ʱ��(����㲻����ʱ������ᵼ���޷����У����������Ϊ��С���ᵼ��һЩ����ֵֹĺ�������������Ҫ��)
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