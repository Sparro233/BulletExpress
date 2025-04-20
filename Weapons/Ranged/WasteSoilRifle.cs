namespace BulletExpress.Weapons.Ranged
{
	public class WasteSoilRifle : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Ranged";
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item40;
            Item.damage = 160;
            Item.knockBack = 3;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.reuseDelay = 0;
            Item.value = 780000;
            Item.rare = 8;

            Item.channel = true;
            Item.autoReuse = false;
            Item.noMelee = true;

            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = 1;
            Item.shootSpeed = 12f;

            Item.width = 16;
            Item.height = 16;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                Item.useTime = 1;
                Item.useAnimation = 1;

                ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            }
            else
            {
                Item.useTime = 10;
                Item.useAnimation = 10;

                ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
            }
            return true;
        }
        
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 4f);
        }
        
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 offset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 16, 0, position + offset, 0, 0))
            {
                position += offset;
            }
        }
    }
}