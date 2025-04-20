namespace BulletExpress.Projectiles.Ranged
{
    public class CurseFlamingBlade : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 255;
            Projectile.width = 0;
            Projectile.height = 0;
            Projectile.scale = 1f;
            DrawOriginOffsetY = 0;
            DrawOffsetX = 0;

            Projectile.timeLeft = 42;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            float v = Projectile.velocity.ToRotation();
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f) ? 1 : -1;
            Projectile.position = player.position + Projectile.velocity * 0f * (250f - Projectile.timeLeft);

            Vector2 unit = Vector2.Normalize(Main.MouseWorld - player.Center);
            float rotaion = unit.ToRotation();
            /*player.itemTime = 20;
            player.itemAnimation = 20;
            player.SetDummyItemTime(20);*/
            player.direction = Main.MouseWorld.X < player.Center.X ? -1 : 1;
            player.itemRotation = (float)Math.Atan2(rotaion.ToRotationVector2().Y * player.direction, rotaion.ToRotationVector2().X * player.direction);
            Vector2 unit2 = Vector2.Normalize(Main.MouseWorld - Projectile.Center);

            if (Vector2.Distance(Projectile.Center, Main.MouseWorld) < 1)
            {
                Projectile.velocity *= 1f;
                Projectile.Center = Main.MouseWorld;
            }
            else
            {
                Projectile.velocity = unit2 * 1;
            }
        }
    }
}