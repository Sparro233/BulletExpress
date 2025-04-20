namespace  BulletExpress.AmmoPro.Bullet
{
    public class PalladiumBullet : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.light = 0.2f;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 4;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            if (Main.rand.NextBool(10))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightII>(), 0f, 0f, 0, default, 1.2f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Type].Value;
            var rot = Projectile.rotation + (float)Math.PI / 2f;
            Main.spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition, null, Color.White, rot,
                tex.Size() / 2f, Projectile.scale, 0, 0);
            return false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 6; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightII>(), 0f, 0f, 0, default, 1.5f);
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(15));
                v2 *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = -v2;
            }
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
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
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.LightII>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
            Player player = Main.player[Projectile.owner];
            player.Heal(1);
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
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.LightII>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
            Player player = Main.player[Projectile.owner];
            player.Heal(1);
        }
    } 
}