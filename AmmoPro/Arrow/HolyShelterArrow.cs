namespace BulletExpress.AmmoPro.Arrow
{
	public class HolyShelterArrow : ModProjectile
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
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightVI>(), 0f, 0f, 55, default, 3f);
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
                //C = 角度, CV = 角向量, Range = 距离, Pos = 位置, off = 执行。
                float C = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(2f, 4f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.LightVI>(), CV * Main.rand.NextFloat(2f, 4f));
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
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.Bless.HolyBless>(), 120);
            for (int i = 0; i < 6; i++)
            {
                //C = 角度, CV = 角向量, Range = 距离, Pos = 位置, off = 执行。
                float C = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(2f, 4f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.LightVI>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.Bless.HolyBless>(), 120);
            for (int i = 0; i < 6; i++)
            {
                //C = 角度, CV = 角向量, Range = 距离, Pos = 位置, off = 执行。
                float C = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(2f, 4f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.LightVI>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
        }
    }
}