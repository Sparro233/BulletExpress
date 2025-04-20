namespace BulletExpress.Projectiles.Horti
{
    public class LightCutting : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 200;
            Projectile.width = 170;
            Projectile.height = 170;
            Projectile.scale = 1.2f;
            DrawOriginOffsetY = 4;
            DrawOffsetX = 17;

            Projectile.timeLeft = 12;
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = 12;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {   
            Projectile.direction = Projectile.spriteDirection = (Projectile.velocity.X > 0f) ? 1 : -1;

            Player player = Main.player[Projectile.owner];
            Projectile.velocity *= 0.96f;

            if (++Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            if (Projectile.ai[0] >= 12f)
                Projectile.Kill();

            //针对单侧垂直
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation += MathHelper.Pi;
            }

            /*if (Projectile.localAI[0] == 0f)
            {
                SoundEngine.PlaySound(SoundID.Item60 with { Volume = 1f }, Projectile.position);
            }*/
        }

        public void FadeInAndOut()
        {   
            //淡入
            if (Projectile.ai[0] <= 50f)
            {
                Projectile.alpha -= 25;
                if (Projectile.alpha < 100)
                    Projectile.alpha = 100;

                return;
            }

            Projectile.alpha += 25;
            if (Projectile.alpha > 255)
                Projectile.alpha = 255;
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);
    }
}