namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class StrawBeetle : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";
        public override void SetDefaults()
        {
            Item.defense = 6;
            Item.value = Item.sellPrice(0, 1, 0, 0);

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateEquip(Player player)
        {
            DamageClass d = ModContent.GetInstance<BulletExpress.HortiDamage>();
            player.GetDamage(d) += 0.12f;
            player.endurance += 0.1f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(1727, 10)
            .AddIngredient(9, 2)
            .Register();
        }
    }
}