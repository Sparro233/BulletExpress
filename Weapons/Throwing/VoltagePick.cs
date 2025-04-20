namespace BulletExpress.Weapons.Throwing
{
    public class VoltagePick : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Throwing";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 90;
            Item.knockBack = 2;
            Item.useTime = 5;
            Item.useAnimation = 10;
            Item.value = Item.sellPrice(0, 26, 0, 0);
            Item.rare = 8;

            Item.useTurn = true;

            Item.pick = 225;
        }
    }
}