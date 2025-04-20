namespace BulletExpress.Projectiles.Ranged
{
    public class Glacier : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            //如果图省事直接使用武器本身贴图，alpha = 255即可。
            Projectile.alpha = 255;
            Projectile.width = 0;
            Projectile.height = 0;
            Projectile.scale = 1f;
            DrawOriginOffsetY = 0;
            DrawOffsetX = 0;
            //存活时间，与物品使用时间相同，reuseDelay 物品冷却时间也应该被考虑进来。
            Projectile.timeLeft = 40;
            //射弹友善，碰撞箱，忽略水
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            //强制使用时间
            /*player.itemTime = 20;
            player.itemAnimation = 20;
            player.SetDummyItemTime(20);*/
            //射弹旋转,贴图对称
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f) ? 1 : -1;
            //寻找玩家和射弹之间的线，锚定射弹跟随玩家的速度
            Player player = Main.player[Projectile.owner];
            Projectile.position = player.position + Projectile.velocity * 0f * (200f - Projectile.timeLeft);
            //寻找玩家和鼠标之间的线，产生跟踪鼠标的速度，并旋转
            Vector2 v = Vector2.Normalize(Main.MouseWorld - player.Center);
            Vector2 v2 = Vector2.Normalize(Main.MouseWorld - Projectile.Center);
            float rotaion = v.ToRotation();
            if (Vector2.Distance(Projectile.Center, Main.MouseWorld) < 1)
            {
                //射弹跟随鼠标的最终速度
                Projectile.velocity *= 1f;
                Projectile.Center = Main.MouseWorld;
            }
            else
            {
                //最终速度
                Projectile.velocity = v2 * 1;
            }
        }
    }
}