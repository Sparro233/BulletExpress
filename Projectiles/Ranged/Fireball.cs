namespace BulletExpress.Projectiles.Ranged
{
    public class Fireball : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetStaticDefaults()
        {
            //射弹动画页数
            Main.projFrames[Projectile.type] = 3;
            ProjectileID.Sets.Explosive[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.scale = 0.8f;
            Projectile.light = 0.5f;
            DrawOriginOffsetY = -13;
            DrawOffsetX = -13;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            float v = Projectile.velocity.ToRotation();
            //滑翔速度
            Projectile.velocity.Y *= 0.96f;
            //下坠加速
            Projectile.velocity.Y += 0.4f;
            //速度流失
            Projectile.velocity *= 0.99f;

            //所有射弹都有有助于延迟某些事件的计时器
            //Projectile.ai[0], Projectile.ai[1] — timers that are automatically synchronized on the client and server
            //Projectile.localAI[0], Projectile.localAI[0] — only on the client

            Projectile.ai[0] += 1f;

            //FadeInAndOut();
            //射弹动画每帧间隔
            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                //或者更紧凑
                //Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            //另一种射弹存活时间方法
            if (Projectile.ai[0] >= 180f)
                Projectile.Kill();
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
            {
                Projectile.velocity.X = oldVelocity.X * -1f;
            }
            if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
            {
                Projectile.velocity.Y = oldVelocity.Y * -1f;
            }
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(24, 300);
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 600);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }

        public override void OnKill(int timeLeft)
        {
            //创建向左移动的速度
            Vector2 v = new Vector2(-2, 0); 
            for (int i = 0; i < 3; i++)
            {
                //每次迭代，将新生成的射弹旋转相当于圆的 1 / 4 （MathHelper.PiOver4）
                //请记住，泰拉瑞亚中的所有旋转都是基于弧度，而不是度数！
                v = v.RotatedBy(MathHelper.PiOver4);
                //生成一个具有新旋转速度的新射弹，属于原始射弹拥有者。新射弹将继承此射弹的生成源
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.MolotovFire, Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
        }
    }
}