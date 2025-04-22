namespace BulletExpress.Projectiles.Ranged
{
    public class ExplodingBowWhiteWing : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 255;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.scale = 1f;
            DrawOriginOffsetY = 0;
            DrawOffsetX = 0;

            Projectile.timeLeft = 64;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].velocity = Vector2.Normalize(-Projectile.velocity) * 12f;
            NetMessage.SendData(MessageID.SyncPlayer, -1, -1, null, Projectile.owner);
        }
    }
}