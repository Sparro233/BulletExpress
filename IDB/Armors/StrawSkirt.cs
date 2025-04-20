namespace BulletExpress.IDB.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    public class StrawSkirt : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Armors";
        public override void SetDefaults()
        {
            Item.defense = 2;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 1;

            Item.width = 16;
            Item.height = 16;
        }

        public override void UpdateEquip(Player player)
        {
            DamageClass d = ModContent.GetInstance<BulletExpress.HortiDamage>();
            player.GetDamage(d) += 0.12f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(1727, 8)
            .AddIngredient(9, 2)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}
