namespace BulletExpress.Projectiles.Melee.Dance
{
    public class RevengeSwordDance : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        // �������Ը�⣬���ǿ���ʹ��ԭ�������������ṩ�����Լ�������
        // public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.Excalibur;

        public override void SetStaticDefaults()
        {
            //����ˮĸ����
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

            Projectile.stopsDealingDamageAfterPenetrateHits = true;//��ֹ�䵯ʱ��ľ�ǰ����
            Projectile.ownerHitCheck = true; //���߼�飬ʹ�䵯�޷�����ͼ������˺�
            Projectile.ownerHitCheckDistance = 300f;//�䵯���Ի���Ŀ��������̡�300 ������ 18.75 ��ͼ��
            //Projectile.usesOwnerMeleeHitCD = true;//ʹ�ý�ս�޵�֡

            //�����ʹ�õ����Զ��� AI������Ӵ��С�����Flask ���Ӿ�Ч�������䵯���������ɣ��������ڻ�����Χ���ɡ�
            //���ǽ��� AI���� ���Լ�Χ�ƻ��������Ӿ�Ч����
            Projectile.noEnchantmentVisuals = true;
        }

        public override void AI()
        {
            // �����ǵ���Ŀ�У��������ɾ��з������ʱ������ŵ��䵯
            // Projectile.ai[0] == direction
            // Projectile.ai[1] == max time
            // Projectile.ai[2] == scale
            // Projectile.localAI[0] == current time

            // Terra Blade ������ʱ�ᷢ�������������
            // if (Projectile.localAI[0] == 0f) {
            // 	SoundEngine.PlaySound(SoundID.Item60 with { Volume = 0.65f }, Projectile.position);
            // }

            Projectile.localAI[0]++; //���账�ڻ״̬�ĵ�ǰʱ�䡣
            Player player = Main.player[Projectile.owner];
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1]; //��ǰʱ�������ʱ��֮�ȡ�
            float direction = Projectile.ai[0];
            float velocityRotation = Projectile.velocity.ToRotation();
            float adjustedRotation = MathHelper.Pi * direction * percentageOfLife + velocityRotation + direction * MathHelper.Pi + player.fullRotation;
            Projectile.rotation = adjustedRotation; //�� rotation ����Ϊ our �����Ǽ��������ת��

            float scaleMulti = 0.6f; // Excalibur��Terra Blade �� The Horseman's Blade �� 0.6f;True Excalibur �� 1f;Ĭ��ֵΪ 0.2F
            float scaleAdder = 1f; // Excalibur��Terra Blade �� The Horseman's Blade �� 1f;True Excalibur �� 1.2f;Ĭ��ֵΪ 1F

            Projectile.Center = player.RotatedRelativePoint(player.MountedCenter) - Projectile.velocity;
            Projectile.scale = scaleAdder + percentageOfLife * scaleMulti;

            //����ʹ�� AI ʽʽ 190 �Ľ��䵯���в�ͬ��Ч����
            //��ʾ�������� Excalibur��
            //�鿴 Projectile.cs �е� AI_190_NightsEdge���� �˽��������ݡ�

            //�������������ǧ�Ļ�������һЩ������
            float dustRotation = Projectile.rotation + Main.rand.NextFloatDirection() * MathHelper.PiOver2 * 0.7f;
            Vector2 dustPosition = Projectile.Center + dustRotation.ToRotationVector2() * 84f * Projectile.scale;
            Vector2 dustVelocity = (dustRotation + Projectile.ai[0] * MathHelper.PiOver2).ToRotationVector2();
            if (Main.rand.NextFloat() * 2f < Projectile.Opacity)
            {
                //ԭʼ Excalibur ��ɫ��Color.Gold�� Color.White
                Color dustColor = Color.Lerp(Color.White, Color.Black, Main.rand.NextFloat() * 0.3f);
                Dust coloredDust = Dust.NewDustPerfect(Projectile.Center + dustRotation.ToRotationVector2() * (Main.rand.NextFloat() * 80f * Projectile.scale + 20f * Projectile.scale), DustID.FireworksRGB, dustVelocity * 1f, 100, dustColor, 0.4f);
                coloredDust.fadeIn = 0.4f + Main.rand.NextFloat() * 0.15f;
                coloredDust.noGravity = true;
            }

            if (Main.rand.NextFloat() * 1.5f < Projectile.Opacity)
            {
                //ԭ�� Excalibur ��ɫ�� Color.White
                Dust.NewDustPerfect(dustPosition, DustID.TintableDustLighted, dustVelocity, 100, Color.SkyBlue * Projectile.Opacity, 1.2f * Projectile.Opacity);
            }

            Projectile.scale *= Projectile.ai[2]; //���䵯�� scale ����Ϊ��Ʒ�� scale��

            //�������������󶯻�ʱ��һ���磬��ɱ�����衣
            if (Projectile.localAI[0] >= Projectile.ai[1])
            {
                Projectile.Kill();
            }

            //��� for ѭ������ʹ�� Flasks��������ע��ʱ�����Ӿ�Ч��
            for (float i = -MathHelper.PiOver4; i <= MathHelper.PiOver4; i += MathHelper.PiOver2)
            {
                Rectangle rectangle = Utils.CenteredRectangle(Projectile.Center + (Projectile.rotation + i).ToRotationVector2() * 70f * Projectile.scale, new Vector2(60f * Projectile.scale, 60f * Projectile.scale));
                Projectile.EmitEnchantmentVisualsAt(rectangle.TopLeft(), rectangle.Width, rectangle.Height);
            }
        }

        //�������ǵ��Զ�����ײ��
        //�����䵯λ��Ŀ�귶Χ��ʱ������ײ�Ż����У���ΧΪ Projectile.ownerHitCheckDistance
        //���ߣ����������δ��������Ŀ�꣬��ʹ�� Projectile.penetrate ���Ի���
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            //�����Բ���ж��Ҳ���Ƿ�Χ�ж��Vanilla ʹ�� 94f ����������Ĵ�С��ƥ�䡣
            float coneLength = 94f * Projectile.scale;
            //�����ֻ�Ӱ����ײ�Ŀ�ʼ�ͽ�������ת����
            //�����ֻ�Ӱ����ײ�Ŀ�ʼ�ͽ�������ת����
            //�ϴ�� Pi ���ֽ���ʱ����ת��ײ��
            //��С�� Pi ���ֽ�˳ʱ����ת��ײ��
            // (Projectile.ai[0] is the direction)
            float collisionRotation = MathHelper.Pi * 2f / 25f * Projectile.ai[0];
            float maximumAngle = MathHelper.PiOver4; // maximumAngle ����������ת�Դ���������
            float coneRotation = Projectile.rotation + collisionRotation;

            // ȡ��ע�ʹ��п�ֱ�۵ر�ʾԲ׶�塣�ҳ���������������������һ�����µĸ��
            // Dust.NewDustPerfect(Projectile.Center + coneRotation.ToRotationVector2() * coneLength, DustID.Pixie, Vector2.Zero);
            // Dust.NewDustPerfect(Projectile.Center, DustID.BlueFairy, new Vector2((float)Math.Cos(maximumAngle) * Projectile.ai[0], (float)Math.Sin(maximumAngle)) * 5f); // Assumes collisionRotation was not changed

            // ���ȣ����Ǽ���һ��Բ׶���Ƿ���Ŀ���ཻ��
            if (targetHitbox.IntersectsConeSlowMoreAccurate(Projectile.Center, coneLength, coneRotation, maximumAngle))
            {
                return true;
            }

            // ��������һ��Բ׶�岢���������ڶ����ߣ����������Ҫ���ڶ���Բ׶���Ƿ�λ��Բ���ı��档
            float backOfTheSwing = Utils.Remap(Projectile.localAI[0], Projectile.ai[1] * 0.3f, Projectile.ai[1] * 0.5f, 1f, 0f);
            if (backOfTheSwing > 0f)
            {
                float coneRotation2 = coneRotation - MathHelper.PiOver4 * Projectile.ai[0] * backOfTheSwing;

                // ȡ��ע�ʹ��п�ֱ�۵ر�ʾԲ׶�塣�ҳ���������������������һ�����µĸ��
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
        // �鿴���� sword ���͵�Դ���롣
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