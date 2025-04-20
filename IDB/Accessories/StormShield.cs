namespace BulletExpress.IDB.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class StormShield : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        //盾击伤害(似乎无效)
        //public const int ShieldSlamDamage = 300;
        //盾牌猛击(未知)
        public const int ShieldSlamIFrames =  60;
        //克盾冲刺加速度
        public const float TabiDashVelocity = 18f;
        //袜子冲刺减速度
        public const float EoCDashVelocity = 18f;

        public override void SetDefaults()
        {
            //伤害
            Item.damage = 300;
            //击退
            Item.knockBack = 4f;
            Item.defense = 6;
            Item.rare = 8;
            Item.value = Item.sellPrice(0, 8, 0, 0);

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            //无击退
            player.noKnockback = true;
            //击退(近战)
            player.GetKnockback(DamageClass.Melee) += 4f;
            //召唤上限
            player.maxMinions += 1;
            //生命上限
            player.statLifeMax2 += 20;
            //魔力上限
            player.statManaMax2 += 20;
            //水平连击次数
            player.dashType = 2;
            //连击后
            if (player.dashType == 2)
            {
                //如果玩家没有用盾牌击中任何东西，并且当前正在发生冲刺，请在冲刺的第一帧增加速度，使其与 Tabi 相同。
                if (player.eocHit == -1 && player.dashDelay == -1)
                {
                    //EoC 冲刺的减速速度比 Tabi 快，因此可以通过将 Tabi 冲刺速度值增加一个近似量来补偿它。
                    if (Math.Abs(player.velocity.X) <= TabiDashVelocity)
                    {
                        player.velocity.X *= TabiDashVelocity / EoCDashVelocity;
                        //决定加速的时间，60帧等于一喵
                        player.dashDelay = 60;
                    }
                    //如果敌人被击中，冲刺延迟减少到 15 帧（原始 30 帧的一半）。
                    if (player.eocHit != -1 && player.dashDelay <= 15)
                    {
                        player.dashDelay = 15;
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Materials.StormBar>(), 12)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}