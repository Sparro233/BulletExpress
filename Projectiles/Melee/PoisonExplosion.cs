namespace BulletExpress.Projectiles.Melee
{ 
    public class PoisonExplosion : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.scale = 2f;
            DrawOffsetX = -32;

            Projectile.timeLeft = 15;
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = 15;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }
        
        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (++Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            if (Projectile.ai[0] >= 15f)
                Projectile.Kill();
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(20, 360);
            Projectile.damage = (int)(Projectile.damage * 0.5f);
        }
        
        public override void OnKill(int timeLeft)
        {
            for (int j = 0; j < 2; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 44, 0f, 0f, 155, default, 0.8f);
                d.velocity *= 1.8f;
            }
        }
    }
}