namespace BulletExpress.Ammo.Bullet
{
    public class HoundiusShootiusFireball : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Ammo.Bullet";
        public override void SetDefaults()
        { 
            Item.damage = 12;
            Item.crit = 72;
            Item.knockBack = 6f;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = 2;

            Item.consumable = true;
            Item.maxStack = 9999;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;

            Item.DamageType = DamageClass.Ranged;
            Item.ammo = AmmoID.Bullet;
            Item.shoot = ProjectileID.HoundiusShootiusFireball;
            Item.shootSpeed = 6f;
            
            Item.width = 16;
            Item.height = 16;
        }
    }
}