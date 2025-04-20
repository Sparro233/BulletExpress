namespace BulletExpress.Projectiles.Horti
{
    public class InkGlassSword : ModProjectile
    {
        //确保横梁不会因其尺寸而立即死亡
        private int tileCounter = 5;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 255;
            Projectile.width = 32;
            Projectile.height = 32;
            DrawOffsetX = -17;

            Projectile.timeLeft = 300;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            float v = Projectile.velocity.ToRotation();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Projectile.rotation = v + 3.14f;
            Projectile.velocity *= 1.01f;

            if (Projectile.timeLeft % 2 == 0)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.FlawlessI>(), 0f, 0f, 85, default, 1.2f);
                d.velocity.Y = 0f;
            }

            Projectile.frameCounter++;
            if (Projectile.frameCounter > 1)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
                if (Projectile.frame > 5)
                {
                    Projectile.frame = 0;
                }
            }

            if (tileCounter > 0)
                tileCounter--;
            if (tileCounter <= 0 && Projectile.ai[1] == 0)
                Projectile.tileCollide = true;

            // til there's a torch id
            Lighting.AddLight(Projectile.Center, TorchID.White); 
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int j = 0; j < 1; j++)
            {
                Vector2 v2 = Main.rand.NextVector2CircularEdge(400f, 400f);
                Vector2 vector2 = v2.SafeNormalize(Vector2.UnitY) * 6f;
                Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - vector2 * 10f, vector2, ProjectileType<Slash>(), Projectile.damage / 2, 0f, Projectile.owner, 0f, target.Center.Y);
            }
            for (int i = 0; i < 20; i++)
            {
                float angle = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 angleVec = angle.ToRotationVector2();
                float distance = Main.rand.NextFloat(7f, 18f);
                Vector2 off = angleVec * distance;
                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(pos, DustID.GemDiamond, angleVec * Main.rand.NextFloat(2f, 4f));
                d.customData = true;
                d.noGravity = true;
                SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity / 2, ModContent.ProjectileType<ThermitI>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            for (int i = 0; i < 20; i++)
            {
                float angle = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 angleVec = angle.ToRotationVector2();
                float distance = Main.rand.NextFloat(7f, 18f);
                Vector2 off = angleVec * distance;
                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(pos, DustID.GemDiamond, angleVec * Main.rand.NextFloat(2f, 4f));
                d.customData = true;
                d.noGravity = true;
                SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
            }
            Projectile.Kill();
            return false;
        }
    }
}