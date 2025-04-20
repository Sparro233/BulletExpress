namespace BulletExpress.Ammo.Bullet
{
    public class MapleLeaveBullet : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.crit = -48;
            Item.knockBack = 2.25f;
            Item.value = Item.sellPrice(0, 0, 0, 25);
            Item.rare = -11;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ModContent.ProjectileType<AmmoPro.Bullet.MapleLeaveBullet>();
            Item.shootSpeed = 8f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
            .AddIngredient(2766)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}