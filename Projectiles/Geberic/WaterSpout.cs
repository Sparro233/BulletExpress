namespace BulletExpress.Projectiles.Geberic
{
    public class WaterSpout : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 255;
            Projectile.width = 150;
            Projectile.height = 42;
            Projectile.scale = 0.6f;

            Projectile.penetrate = -1;
            Projectile.timeLeft = 120;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            int projScale1 = 10;
            int projScale2 = 15;
            float thirdProjScale = 1f;
            int projWidthScale = 150;
            int projHeightScale = 42;
            if (Projectile.velocity.X != 0f)
            {
                Projectile.direction = Projectile.spriteDirection = -Math.Sign(Projectile.velocity.X);
            }
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 2)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame >= 6)
            {
                Projectile.frame = 0;
            }
            if (Projectile.localAI[0] == 0f)
            {
                Projectile.localAI[0] = 1f;
                Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
                Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
                Projectile.scale = ((float)(projScale1 + projScale2) - Projectile.ai[1]) * thirdProjScale / (float)(projScale2 + projScale1);
                Projectile.width = (int)((float)projWidthScale * Projectile.scale);
                Projectile.height = (int)((float)projHeightScale * Projectile.scale);
                Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
                Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
                Projectile.netUpdate = true;
            }
            if (Projectile.ai[1] != -1f)
            {
                Projectile.scale = ((float)(projScale1 + projScale2) - Projectile.ai[1]) * thirdProjScale / (float)(projScale2 + projScale1);
                Projectile.width = (int)((float)projWidthScale * Projectile.scale);
                Projectile.height = (int)((float)projHeightScale * Projectile.scale);
            }
            if (!Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
            {
                Projectile.alpha -= 30;
                if (Projectile.alpha < 60)
                {
                    Projectile.alpha = 60;
                }
            }
            else
            {
                Projectile.alpha += 30;
                if (Projectile.alpha > 150)
                {
                    Projectile.alpha = 150;
                }
            }
            if (Projectile.ai[0] > 0f)
            {
                Projectile.ai[0] -= 1f;
            }
            if (Projectile.ai[0] == 1f && Projectile.ai[1] > 0f && Projectile.owner == Main.myPlayer)
            {
                Projectile.netUpdate = true;
                Vector2 center = Projectile.Center;
                center.Y -= (float)projHeightScale * Projectile.scale / 2f;
                float projSpawn = ((float)(projScale1 + projScale2) - Projectile.ai[1] + 1f) * thirdProjScale / (float)(projScale2 + projScale1);
                center.Y -= (float)projHeightScale * projSpawn / 2f;
                center.Y += 2f;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), center.X, center.Y, Projectile.velocity.X, Projectile.velocity.Y, Projectile.type, Projectile.damage, Projectile.knockBack, Projectile.owner, 10f, Projectile.ai[1] - 1f);
            }
            if (Projectile.ai[0] <= 0f)
            {
                float swaySize = MathHelper.Pi / 30f;
                float smolWidth = (float)Projectile.width / 5f;
                float projXChange = (float)(Math.Cos((double)(swaySize * -(double)Projectile.ai[0])) - 0.5) * smolWidth;
                Projectile.position.X = Projectile.position.X - projXChange * (float)-(float)Projectile.direction;
                Projectile.ai[0] -= 1f;
                projXChange = (float)(Math.Cos((double)(swaySize * -(double)Projectile.ai[0])) - 0.5) * smolWidth;
                Projectile.position.X = Projectile.position.X + projXChange * (float)-(float)Projectile.direction;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            int framing = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type];
            int y6 = framing * Projectile.frame;
            Main.spriteBatch.Draw(texture2D13, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Rectangle(0, y6, texture2D13.Width, framing)), Projectile.GetAlpha(lightColor), Projectile.rotation, new Vector2((float)texture2D13.Width / 2f, (float)framing / 2f), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.timeLeft -= 10;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 8; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 0, default, 1.5f);
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(15));
                d.velocity.X = 0f;
                d.velocity.Y = 0.8f;
            }
        }
    }
}
