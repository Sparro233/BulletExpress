namespace BulletExpress.IDB.Accessories
{
    public class TechnologyChip : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        /*public override void SetStaticDefaults()
        {
            //直接命中造成双倍伤害
            //ProjectileID.Sets.IsARocketThatDealsDoubleDamageToPrimaryEnemy[Type] = true; 
            //防止爆炸伤害因难度提高
            //ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true; 
            //PVPandFTW可以命中其他玩家
            //ProjectileID.Sets.Explosive[Type] = true;
            //爆炸伤害可以命中玩家
            //ProjectileID.Sets.RocketsSkipDamageForPlayers[Type] = true;
        }*/
        public override void SetDefaults()
        {
            Item.holdStyle = 6;
            Item.useStyle = 14;
            Item.UseSound = SoundID.Item15;
            Item.useTime = 1;
            Item.useAnimation = 60;
            Item.rare = 1;
            Item.value = Item.sellPrice(0, 1, 0, 0);

            Item.autoReuse = true;
            Item.useTurn = true;

            Item.hammer = 1000;
            Item.scale = 1f;

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            //伤害穿透
            player.GetArmorPenetration(DamageClass.Generic) += 2;
            //移动速度
            player.moveSpeed += 0.2f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(182)
            .AddRecipeGroup("AnyBar", 20)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
        }
    }
}