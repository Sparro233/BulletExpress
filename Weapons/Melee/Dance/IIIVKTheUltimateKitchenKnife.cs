namespace BulletExpress.Weapons.Melee.Dance
{
	public class IIIVKTheUltimateKitchenKnife : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Melee";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Item.useStyle = 1;
            Item.UseSound = SoundID.Item1;
            Item.damage = 20;
            Item.knockBack = 2;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.value = 18000;
            Item.rare = 1;

            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.Dance.IIIVKTheUltimateKitchenKnife>();
            Item.shootSpeed = 1.1f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust newDust = Dust.NewDustDirect(hitbox.TopLeft(), hitbox.Width, hitbox.Height, ModContent.DustType<IDA.Powders.Light>()/*DustID.Ichor*/);
            newDust.velocity *= 0;
            newDust.noGravity = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item);
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI);

            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void AddRecipes()
        {
            //Mod LastWishTravel = ModLoader.GetMod("LastWishTravel");
            //if (LastWishTravel != null)
            //{
            //    CreateRecipe()
            //    .AddIngredient(ItemID.HallowedBar, 7)
            //    .AddIngredient(LastWishTravel, "LightMass", 7)
            //    .AddIngredient(547, 1)
            //    .AddIngredient(548, 1)
            //    .AddIngredient(549, 1)
            //    .AddTile(TileID.LunarCraftingStation)
            //    .Register();
            //}
            //else
            //{
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.LightBar>(), 14)
            .AddTile(TileID.Anvils)
            .Register();
            //}
        }
    }
}