namespace BulletExpress.AmmoPro.Bullet
{
	public class HighVelocityNanoBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            //生成时透明度
            Projectile.alpha = 255;
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.light = 0.2f;

            Projectile.timeLeft = 400;
            //动态刷新次数
            Projectile.extraUpdates = 4;
            Projectile.penetrate = 2;
            //无敌帧
            Projectile.localNPCHitCooldown = 20;
            //独立无敌帧
            Projectile.usesLocalNPCImmunity = true;
            //友善
            Projectile.friendly = true;
            //忽略水
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            if (Projectile.penetrate <= 1)
            {
                int index = Projectile.FindTargetWithLineOfSight(320);
                if (index >= 0)
                {
                    NPC npc = Main.npc[index];
                    Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f;
                }
            }
            Projectile.alpha -= 10;
            if (Projectile.alpha < 15)
            {
                Projectile.alpha = 15;
            }
        }

        public void FadeInAndOut()
        {
            if (Projectile.ai[0] <= 1f)
            {
                Projectile.alpha += 10;
                if (Projectile.alpha < 240)
                    Projectile.alpha = 240;

                return;
            }

            Projectile.alpha -= 10;
            if (Projectile.alpha > 240)
                Projectile.alpha = 240;
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
            Projectile.alpha = 240;
            if (Projectile.penetrate <= 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 0, default, 1.5f);
                    Vector2 v = Projectile.velocity;
                    Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(15));
                    v2 *= 1f - Main.rand.NextFloat(0.9f);
                    d.velocity = v2;
                }
            }
            if (Projectile.penetrate > 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 0, default, 1.5f);
                    Vector2 v = Projectile.velocity;
                    Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(15));
                    v2 *= 1f - Main.rand.NextFloat(0.9f);
                    d.velocity = -v2;
                }
            }
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 8; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 0, default, 1.5f);
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(15));
                v2 *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = v2;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(31, 600);
            for (int i = 0; i < 8; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 0, default, 1.5f);
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(15));
                v2 *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = v2;
            }
            Projectile.damage = (int)(Projectile.damage * 0.5f);
        }
    }
}