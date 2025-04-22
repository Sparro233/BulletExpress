namespace BulletExpress.Weapons.Energy
{
    public class Jyorat : ModItem, ILocalizedModType
    {
        public new string LocalizationCategory => "Weapons.Energy";
        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item35;
            Item.damage = 320;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.value = Item.sellPrice(0, 80, 0, 0);
            Item.rare = 8;

            Item.staff[Type] = true;
            Item.autoReuse = true;
            Item.noMelee = true;

            Item.mana = 24;

            Item.shoot = ModContent.ProjectileType<Projectiles.Energy.LightRain>();
            Item.shootSpeed = 24f;
            Item.scale = 1.2f;
            
            Item.width = 16;
            Item.height = 16;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y + 200f)
            {
                ceilingLimit = player.Center.Y + 200f;
            }
            for (int i = 0; i < 6; i++)
            {
                position = player.Center - new Vector2(Main.rand.NextFloat(1200) * player.direction, 600f);
                position.Y -= 100 * i;
                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 60f)
                {
                    heading.Y = 60f;
                }

                heading.Normalize();
                heading *= velocity.Length();
                heading.Y += Main.rand.Next(-300, 300) * 0.02f;
                Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
            }
            return false;
        }
        
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<IDB.Materials.StormBar>(), 7)
            .AddIngredient(ModContent.ItemType<IDB.Materials.LightBar>(), 7)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
        }
    }
}
