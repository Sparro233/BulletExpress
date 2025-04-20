namespace BulletExpress.Ammo.Flare
{
    public class ThunderZapperBullet : ModItem
    {
        public override void SetDefaults()
        { 
            Item.damage = 120;
            Item.crit = 72;
            Item.knockBack = 3f;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = 3;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Flare;
            Item.shoot = 731;
            Item.shootSpeed = 2f;
            
            Item.width = 16;
            Item.height = 16;
        }
    }
}