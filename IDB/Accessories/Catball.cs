namespace BulletExpress.IDB.Accessories
{
    public class Catball : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Accessories";
        public override void SetDefaults()
        {
            Item.defense = 6;
            Item.rare = 4;

            Item.accessory = true;

            Item.width = 16;
            Item.height = 16;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //伤害
            player.GetDamage(DamageClass.Generic) += 0.06f;
            //暴击
            player.GetCritChance(DamageClass.Generic) += 6f;
            //攻击速度
            player.GetAttackSpeed(DamageClass.Generic) += 0.06f;
            //移动速度
            player.moveSpeed -= 0.06f;
            //伤害减免
            player.endurance -= 0.06f;
        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.DemoniteBar, 6)
            .AddIngredient(ItemID.SoulofNight, 6)
            .AddIngredient(ModContent.ItemType<IDB.Materials.StrayCotton>(), 6)
            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}