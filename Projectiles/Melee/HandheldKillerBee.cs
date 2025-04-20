namespace BulletExpress.Projectiles.Melee
{
    public class HandheldKillerBee : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Spear); 

            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 58;
            Projectile.height = 58;

            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = 10;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        //定义 Spear Projectile 的范围。这些是可重写的属性，以防你想创建一个继承自这个属性的类。
        protected virtual float HoldoutRangeMin => 30f;
        protected virtual float HoldoutRangeMax => 100f;

        public override bool PreAI()
        {
            //由于我们经常访问所有者玩家实例，因此为此创建一个辅助局部变量很有用
            Player player = Main.player[Projectile.owner]; 
            //定义射弹在帧中存在的持续时间
            int duration = player.itemAnimationMax;
            //更新玩家手持的射弹 ID
            player.heldProj = Projectile.whoAmI;

            //如有必要，重置剩余的射弹时间
            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
            }

            //Velocity 在这个 spear 实现中没有使用，但我们使用 field 来存储 spear 的攻击方向。
            Projectile.velocity = Vector2.Normalize(Projectile.velocity);

            //定义矛的运动期间
            float half = duration * 0.5f;
            float progress;

            //progress = 期间，half = 半个期间，duration = 完整期间。
            if (Projectile.timeLeft < half)
            {
                progress = Projectile.timeLeft / half;
            }
            else
            {
                progress = (duration - Projectile.timeLeft) / half;
            }

            //将射弹从 HoldoutRangeMin = 最小维持范围 移动到 HoldoutRangeMax = 最大维持范围 并移回，使用 SmoothStep = 平滑步长 来缓和移动
            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

            //对 射弹 应用适当的旋转。
            if (Projectile.spriteDirection == -1)
            {
                //如果 射弹 朝左，则旋转 45 度
                Projectile.rotation += MathHelper.ToRadians(35f);
            }
            else
            {
                //如果 射弹 朝右，则旋转 135 度
                Projectile.rotation += MathHelper.ToRadians(145f);
            }
            if (!Main.dedServ)
            {
                if (Main.rand.NextBool(3))
                {
                    Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Projectile.velocity.X * 2f, Projectile.velocity.Y * 2f, Alpha: 128, Scale: 1.2f);
                }
                if (Main.rand.NextBool(4))
                {
                    Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, Alpha: 128, Scale: 0.3f);
                }
            }
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(4, -4)); 
                
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<PoisonExplosionBee>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            }
        }
    }
}