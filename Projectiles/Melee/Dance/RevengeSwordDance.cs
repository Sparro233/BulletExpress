namespace BulletExpress.Projectiles.Melee.Dance
{
    public class RevengeSwordDance : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        // 如果我们愿意，我们可以使用原版纹理，而不是提供我们自己的纹理。
        // public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.Excalibur;

        public override void SetStaticDefaults()
        {
            //攻击水母触电
            ProjectileID.Sets.AllowsContactDamageFromJellyfish[Type] = true;
            Main.projFrames[Type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 3;

            Projectile.localNPCHitCooldown = 20;
            Projectile.usesLocalNPCImmunity = true;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;

            Projectile.stopsDealingDamageAfterPenetrateHits = true;//防止射弹时间耗尽前死亡
            Projectile.ownerHitCheck = true; //视线检查，使射弹无法穿过图格造成伤害
            Projectile.ownerHitCheckDistance = 300f;//射弹可以击中目标的最大射程。300 像素是 18.75 个图块
            //Projectile.usesOwnerMeleeHitCD = true;//使用近战无敌帧

            //如果您使用的是自定义 AI，请添加此行。否则，Flask 的视觉效果将在射弹的中心生成，而不是在弧线周围生成。
            //我们将在 AI（） 中自己围绕弧线生成视觉效果。
            Projectile.noEnchantmentVisuals = true;
        }

        public override void AI()
        {
            // 在我们的项目中，我们生成具有方向、最大时间和缩放的射弹
            // Projectile.ai[0] == direction
            // Projectile.ai[1] == max time
            // Projectile.ai[2] == scale
            // Projectile.localAI[0] == current time

            // Terra Blade 在生成时会发出额外的声音。
            // if (Projectile.localAI[0] == 0f) {
            // 	SoundEngine.PlaySound(SoundID.Item60 with { Volume = 0.65f }, Projectile.position);
            // }

            Projectile.localAI[0]++; //弹丸处于活动状态的当前时间。
            Player player = Main.player[Projectile.owner];
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1]; //当前时间与最大时间之比。
            float direction = Projectile.ai[0];
            float velocityRotation = Projectile.velocity.ToRotation();
            float adjustedRotation = MathHelper.Pi * direction * percentageOfLife + velocityRotation + direction * MathHelper.Pi + player.fullRotation;
            Projectile.rotation = adjustedRotation; //将 rotation 设置为 our 到我们计算的新旋转。

            float scaleMulti = 0.6f; // Excalibur、Terra Blade 和 The Horseman's Blade 是 0.6f;True Excalibur 是 1f;默认值为 0.2F
            float scaleAdder = 1f; // Excalibur、Terra Blade 和 The Horseman's Blade 是 1f;True Excalibur 是 1.2f;默认值为 1F

            Projectile.Center = player.RotatedRelativePoint(player.MountedCenter) - Projectile.velocity;
            Projectile.scale = scaleAdder + percentageOfLife * scaleMulti;

            //其他使用 AI 式式 190 的剑射弹具有不同的效果。
            //此示例仅包括 Excalibur。
            //查看 Projectile.cs 中的 AI_190_NightsEdge（） 了解其他内容。

            //在这里，我们在秋千的弧内生成一些尘埃。
            float dustRotation = Projectile.rotation + Main.rand.NextFloatDirection() * MathHelper.PiOver2 * 0.7f;
            Vector2 dustPosition = Projectile.Center + dustRotation.ToRotationVector2() * 84f * Projectile.scale;
            Vector2 dustVelocity = (dustRotation + Projectile.ai[0] * MathHelper.PiOver2).ToRotationVector2();
            if (Main.rand.NextFloat() * 2f < Projectile.Opacity)
            {
                //原始 Excalibur 颜色：Color.Gold， Color.White
                Color dustColor = Color.Lerp(Color.White, Color.Black, Main.rand.NextFloat() * 0.3f);
                Dust coloredDust = Dust.NewDustPerfect(Projectile.Center + dustRotation.ToRotationVector2() * (Main.rand.NextFloat() * 80f * Projectile.scale + 20f * Projectile.scale), DustID.FireworksRGB, dustVelocity * 1f, 100, dustColor, 0.4f);
                coloredDust.fadeIn = 0.4f + Main.rand.NextFloat() * 0.15f;
                coloredDust.noGravity = true;
            }

            if (Main.rand.NextFloat() * 1.5f < Projectile.Opacity)
            {
                //原款 Excalibur 颜色： Color.White
                Dust.NewDustPerfect(dustPosition, DustID.TintableDustLighted, dustVelocity, 100, Color.SkyBlue * Projectile.Opacity, 1.2f * Projectile.Opacity);
            }

            Projectile.scale *= Projectile.ai[2]; //将射弹的 scale 设置为物品的 scale。

            //如果弹射物与最大动画时间一样早，则杀死弹丸。
            if (Projectile.localAI[0] >= Projectile.ai[1])
            {
                Projectile.Kill();
            }

            //这个 for 循环会在使用 Flasks（武器灌注）时生成视觉效果
            for (float i = -MathHelper.PiOver4; i <= MathHelper.PiOver4; i += MathHelper.PiOver2)
            {
                Rectangle rectangle = Utils.CenteredRectangle(Projectile.Center + (Projectile.rotation + i).ToRotationVector2() * 70f * Projectile.scale, new Vector2(60f * Projectile.scale, 60f * Projectile.scale));
                Projectile.EmitEnchantmentVisualsAt(rectangle.TopLeft(), rectangle.Width, rectangle.Height);
            }
        }

        //这是我们的自定义碰撞。
        //仅当射弹位于目标范围内时，此碰撞才会运行，范围为 Projectile.ownerHitCheckDistance
        //或者，如果弹丸尚未击中所有目标，则使用 Projectile.penetrate 可以击中
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            //这就是圆周有多大，也就是范围有多大。Vanilla 使用 94f 将其与纹理的大小相匹配。
            float coneLength = 94f * Projectile.scale;
            //此数字会影响碰撞的开始和结束的旋转量。
            //此数字会影响碰撞的开始和结束的旋转量。
            //较大的 Pi 数字将逆时针旋转碰撞。
            //较小的 Pi 数字将顺时针旋转碰撞。
            // (Projectile.ai[0] is the direction)
            float collisionRotation = MathHelper.Pi * 2f / 25f * Projectile.ai[0];
            float maximumAngle = MathHelper.PiOver4; // maximumAngle 用于限制旋转以创建死区。
            float coneRotation = Projectile.rotation + collisionRotation;

            // 取消注释此行可直观地表示圆锥体。灰尘并不完美，但它给出了一个大致的概念。
            // Dust.NewDustPerfect(Projectile.Center + coneRotation.ToRotationVector2() * coneLength, DustID.Pixie, Vector2.Zero);
            // Dust.NewDustPerfect(Projectile.Center, DustID.BlueFairy, new Vector2((float)Math.Cos(maximumAngle) * Projectile.ai[0], (float)Math.Sin(maximumAngle)) * 5f); // Assumes collisionRotation was not changed

            // 首先，我们检查第一个圆锥体是否与目标相交。
            if (targetHitbox.IntersectsConeSlowMoreAccurate(Projectile.Center, coneLength, coneRotation, maximumAngle))
            {
                return true;
            }

            // 不过，第一个圆锥体并不是整个摆动弧线，因此我们需要检查第二个圆锥体是否位于圆弧的背面。
            float backOfTheSwing = Utils.Remap(Projectile.localAI[0], Projectile.ai[1] * 0.3f, Projectile.ai[1] * 0.5f, 1f, 0f);
            if (backOfTheSwing > 0f)
            {
                float coneRotation2 = coneRotation - MathHelper.PiOver4 * Projectile.ai[0] * backOfTheSwing;

                // 取消注释此行可直观地表示圆锥体。灰尘并不完美，但它给出了一个大致的概念。
                // Dust.NewDustPerfect(Projectile.Center + coneRotation2.ToRotationVector2() * coneLength, DustID.Enchanted_Pink, Vector2.Zero);
                // Dust.NewDustPerfect(Projectile.Center, DustID.BlueFairy, new Vector2((float)Math.Cos(backOfTheSwing) * -Projectile.ai[0], (float)Math.Sin(backOfTheSwing)) * 5f); // Assumes collisionRotation was not changed

                if (targetHitbox.IntersectsConeSlowMoreAccurate(Projectile.Center, coneLength, coneRotation2, maximumAngle))
                {
                    return true;
                }
            }

            return false;
        }

        // Taken from Main.DrawProj_Excalibur()
        // 查看其他 sword 类型的源代码。
        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 position = Projectile.Center - Main.screenPosition;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Rectangle sourceRectangle = texture.Frame(1, 4); // The sourceRectangle says which frame to use.
            Vector2 origin = sourceRectangle.Size() / 2f;
            float scale = Projectile.scale * 1.1f;
            SpriteEffects spriteEffects = ((!(Projectile.ai[0] >= 0f)) ? SpriteEffects.FlipVertically : SpriteEffects.None); // Flip the sprite based on the direction it is facing.
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1]; // The current time over the max time.
            float lerpTime = Utils.Remap(percentageOfLife, 0f, 0.6f, 0f, 1f) * Utils.Remap(percentageOfLife, 0.6f, 1f, 1f, 0f);
            float lightingColor = Lighting.GetColor(Projectile.Center.ToTileCoordinates()).ToVector3().Length() / (float)Math.Sqrt(3.0);
            lightingColor = Utils.Remap(lightingColor, 0.2f, 1f, 0f, 1f);

            Color backDarkColor = new Color(20, 20, 20); // Original Excalibur color: Color(180, 160, 60)
            Color middleMediumColor = new Color(210, 210 ,210); // Original Excalibur color: Color(255, 255, 80)
            Color frontLightColor = new Color(180, 180, 180); // Original Excalibur color: Color(255, 240, 150)

            Color whiteTimesLerpTime = Color.White * lerpTime * 0.5f;
            whiteTimesLerpTime.A = (byte)(whiteTimesLerpTime.A * (1f - lightingColor));
            Color faintLightingColor = whiteTimesLerpTime * lightingColor * 0.5f;
            faintLightingColor.G = (byte)(faintLightingColor.G * lightingColor);
            faintLightingColor.B = (byte)(faintLightingColor.R * (0.25f + lightingColor * 0.75f));

            // Back part
            Main.EntitySpriteDraw(texture, position, sourceRectangle, backDarkColor * lightingColor * lerpTime, Projectile.rotation + Projectile.ai[0] * MathHelper.PiOver4 * -1f * (1f - percentageOfLife), origin, scale, spriteEffects, 0f);
            // Very faint part affected by the light color
            Main.EntitySpriteDraw(texture, position, sourceRectangle, faintLightingColor * 0.15f, Projectile.rotation + Projectile.ai[0] * 0.01f, origin, scale, spriteEffects, 0f);
            // Middle part
            Main.EntitySpriteDraw(texture, position, sourceRectangle, middleMediumColor * lightingColor * lerpTime * 0.3f, Projectile.rotation, origin, scale, spriteEffects, 0f);
            // Front part
            Main.EntitySpriteDraw(texture, position, sourceRectangle, frontLightColor * lightingColor * lerpTime * 0.5f, Projectile.rotation, origin, scale * 0.975f, spriteEffects, 0f);
            // Thin top line (final frame)
            Main.EntitySpriteDraw(texture, position, texture.Frame(1, 4, 0, 3), Color.White * 0.6f * lerpTime, Projectile.rotation + Projectile.ai[0] * 0.01f, origin, scale, spriteEffects, 0f);
            // Thin middle line (final frame)
            Main.EntitySpriteDraw(texture, position, texture.Frame(1, 4, 0, 3), Color.White * 0.5f * lerpTime, Projectile.rotation + Projectile.ai[0] * -0.05f, origin, scale * 0.8f, spriteEffects, 0f);
            // Thin bottom line (final frame)
            Main.EntitySpriteDraw(texture, position, texture.Frame(1, 4, 0, 3), Color.White * 0.4f * lerpTime, Projectile.rotation + Projectile.ai[0] * -0.1f, origin, scale * 0.6f, spriteEffects, 0f);

            // This draws some sparkles around the circumference of the swing.
            for (float i = 0f; i < 8f; i += 1f)
            {
                float edgeRotation = Projectile.rotation + Projectile.ai[0] * i * (MathHelper.Pi * -2f) * 0.025f + Utils.Remap(percentageOfLife, 0f, 1f, 0f, MathHelper.PiOver4) * Projectile.ai[0];
                Vector2 drawPos = position + edgeRotation.ToRotationVector2() * ((float)texture.Width * 0.5f - 6f) * scale;
                DrawPrettyStarSparkle(Projectile.Opacity, SpriteEffects.None, drawPos, new Color(255, 255, 255, 0) * lerpTime * (i / 9f), middleMediumColor, percentageOfLife, 0f, 0.5f, 0.5f, 1f, edgeRotation, new Vector2(0f, Utils.Remap(percentageOfLife, 0f, 1f, 3f, 0f)) * scale, Vector2.One * scale);
            }

            // This draws a large star sparkle at the front of the projectile.
            Vector2 drawPos2 = position + (Projectile.rotation + Utils.Remap(percentageOfLife, 0f, 1f, 0f, MathHelper.PiOver4) * Projectile.ai[0]).ToRotationVector2() * ((float)texture.Width * 0.5f - 4f) * scale;
            DrawPrettyStarSparkle(Projectile.Opacity, SpriteEffects.None, drawPos2, new Color(255, 255, 255, 0) * lerpTime * 0.5f, middleMediumColor, percentageOfLife, 0f, 0.5f, 0.5f, 1f, 0f, new Vector2(2f, Utils.Remap(percentageOfLife, 0f, 1f, 4f, 1f)) * scale, Vector2.One * scale);

            // Uncomment this line for a visual representation of the projectile's size.
            // Main.EntitySpriteDraw(TextureAssets.MagicPixel.Value, position, sourceRectangle, Color.Orange * 0.75f, 0f, origin, scale, spriteEffects);

            return false;
        }

        // Copied from Main.DrawPrettyStarSparkle() which is private
        private static void DrawPrettyStarSparkle(float opacity, SpriteEffects dir, Vector2 drawPos, Color drawColor, Color shineColor, float flareCounter, float fadeInStart, float fadeInEnd, float fadeOutStart, float fadeOutEnd, float rotation, Vector2 scale, Vector2 fatness)
        {
            Texture2D sparkleTexture = TextureAssets.Extra[98].Value;
            Color bigColor = shineColor * opacity * 0.5f;
            bigColor.A = 0;
            Vector2 origin = sparkleTexture.Size() / 2f;
            Color smallColor = drawColor * 0.5f;
            float lerpValue = Utils.GetLerpValue(fadeInStart, fadeInEnd, flareCounter, clamped: true) * Utils.GetLerpValue(fadeOutEnd, fadeOutStart, flareCounter, clamped: true);
            Vector2 scaleLeftRight = new Vector2(fatness.X * 0.5f, scale.X) * lerpValue;
            Vector2 scaleUpDown = new Vector2(fatness.Y * 0.5f, scale.Y) * lerpValue;
            bigColor *= lerpValue;
            smallColor *= lerpValue;
            // Bright, large part
            Main.EntitySpriteDraw(sparkleTexture, drawPos, null, bigColor, MathHelper.PiOver2 + rotation, origin, scaleLeftRight, dir);
            Main.EntitySpriteDraw(sparkleTexture, drawPos, null, bigColor, 0f + rotation, origin, scaleUpDown, dir);
            // Dim, small part
            Main.EntitySpriteDraw(sparkleTexture, drawPos, null, smallColor, MathHelper.PiOver2 + rotation, origin, scaleLeftRight * 0.6f, dir);
            Main.EntitySpriteDraw(sparkleTexture, drawPos, null, smallColor, 0f + rotation, origin, scaleUpDown * 0.6f, dir);
        }
    }
}