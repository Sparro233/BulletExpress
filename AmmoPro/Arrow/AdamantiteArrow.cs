namespace BulletExpress.AmmoPro.Arrow
{
	public class AdamantiteArrow : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;

            Projectile.arrow = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.ai[0] = 30f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
            }
            if (Main.rand.NextBool(20))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightIV>(), 0f, 0f, 55, default, 2f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 6; i++)
            {
                //C = 角度, CV = 角向量, Range = 距离, Pos = 位置, off = 执行。
                float C = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(2f, 4f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.LightIV>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 6; i++)
            {
                //C = 角度, CV = 角向量, Range = 距离, Pos = 位置, off = 执行。
                float C = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(2f, 4f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.LightIV>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 6; i++)
            {
                //C = 角度, CV = 角向量, Range = 距离, Pos = 位置, off = 执行。
                float C = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(2f, 4f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.LightIV>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
        }
    }
}