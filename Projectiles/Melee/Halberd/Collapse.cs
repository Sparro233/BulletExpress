namespace BulletExpress.Projectiles.Melee.Halberd
{
    public class Collapse : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        public override void SetStaticDefaults()
        {
            //被其他比武长戟命中会下马
            ProjectileID.Sets.DismountsPlayersOnHit[Type] = true;
            //这将确保射弹的速度始终是物品中设置的射击速度
            //由于射弹的速度会影响比武长枪的生成距离，因此我们希望速度始终相同，即使玩家的攻击速度有所提高
            ProjectileID.Sets.NoMeleeSpeedVelocityScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            //生成时透明度
            Projectile.alpha = 255;
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.scale = 1.1f;

            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.ownerHitCheck = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.hide = true;
        }

        // 这是 Jousting Lances 使用的自定义碰撞
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float rotationFactor = Projectile.rotation + (float)Math.PI / 4f; // 比武长枪的旋转
            float scaleFactor = 95f; // 命中线距离比武长枪的尖端有多远。如果您有更长或更短的 Jousting Lance，则需要修改此设置。原版使用 95f
            float widthMultiplier = 23f; // 命中线有多粗。如果您的比武长枪更厚或更薄，请增加或减少此值。原版使用 23f
            float collisionPoint = 0f; // collisionPoint 是 CheckAABBvLineCollision（） 所必需的，但它不用于此处的碰撞。保持 0f

            // 这个矩形是比武长枪的碰撞框的宽度和高度，用于碰撞的第一步
            // 如果您有更大或更小的 Jousting Lance，您将需要修改最后两个数字
            // 原版使用 （0， 0， 300， 300），这对于比武长枪的大小来说是相当大的
            // 大小并不重要，因为这个矩形只是碰撞的基本检查（命中线更重要）
            Rectangle lanceHitboxBounds = new Rectangle(0, 0, 300, 300);

            // 设置大矩形的位置。
            lanceHitboxBounds.X = (int)Projectile.position.X - lanceHitboxBounds.Width / 2;
            lanceHitboxBounds.Y = (int)Projectile.position.Y - lanceHitboxBounds.Height / 2;

            // 这是命中线的背面，Projectile.Center 是比武长枪的尖端
            Vector2 hitLineEnd = Projectile.Center + rotationFactor.ToRotationVector2() * scaleFactor;

            // 以下是调试 hit 行的大小。这将使您能够轻松查看它的开始和结束位置
            // Dust.NewDustPerfect(Projectile.Center, DustID.Pixie, Velocity: Vector2.Zero, Scale: 0.5f);
            // Dust.NewDustPerfect(hitLineEnd, DustID.Pixie, Velocity: Vector2.Zero, Scale: 0.5f);

            // 首先检查我们的大矩形是否与目标碰撞箱相交
            // 然后我们检查从比武枪尖到长枪“末端”的线条是否与目标碰撞箱相交
            if (lanceHitboxBounds.Intersects(targetHitbox)
                && Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, hitLineEnd, widthMultiplier * Projectile.scale, ref collisionPoint))
            {
                return true;
            }
            return false;
        }

        // 我们需要手动绘制弹丸。如果你不包括这个，骑枪将不会与玩家对齐
        public override bool PreDraw(ref Color lightColor)
        {
            // SpriteEffects 会更改 Sprite 的绘制方向
            SpriteEffects spriteEffects = SpriteEffects.None;
            // 获取弹丸的纹理
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            // 获取纹理上当前选定的帧
            Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Type], frameY: Projectile.frame);
            // 在这种情况下，原点是 （0， 0） 的弹丸，因为 Projectile.Center 是我们的骑枪尖端
            Vector2 origin = Vector2.Zero;
            // 弹射物的旋转
            float rotation = Projectile.rotation;

            // 如果弹丸朝右，我们需要将其旋转 -90 度，移动原点，并水平翻转 sprite
            // 这将使 sprite 的底部在向右射击时正确地朝下
            if (Projectile.direction > 0)
            {
                rotation -= (float)Math.PI / 2f;
                origin.X += sourceRectangle.Width;
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            // 精灵的位置。不减去 Main.player[Projectile.owner].gfxOffY 将导致 sprite 在上方块时反弹
            Vector2 position = new(Projectile.Center.X, Projectile.Center.Y - Main.player[Projectile.owner].gfxOffY);
            // 应用光照并绘制我们的射弹
            Color drawColor = Projectile.GetAlpha(lightColor);

            Main.EntitySpriteDraw(texture,
                position - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, drawColor, rotation, origin, Projectile.scale, spriteEffects, 0);

            // 以下是调试碰撞矩形的大小。将此大小设置为与 Colliding（） 中的大小相同
            // Rectangle lanceHitboxBounds = new Rectangle(0, 0, 300, 300);
            // Main.EntitySpriteDraw(TextureAssets.MagicPixel.Value,
            // new Vector2((int)Projectile.Center.X - lanceHitboxBounds.Width / 2, (int)Projectile.Center.Y - lanceHitboxBounds.Height / 2) - Main.screenPosition,
            // lanceHitboxBounds, Color.Orange * 0.5f, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);

            // 返回 false 很重要，否则我们也会绘制原始纹理
            return false;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner]; // 获取弹丸的所有者
            Projectile.direction = owner.direction; // 面向左侧时，方向将为 -1，面向右侧时为 +1
            owner.heldProj = Projectile.whoAmI; // 将拥有者持有的弹射物设置为此弹射物。heldProj 的 intent 会在玩家死亡或交换物品时杀死射弹

            int itemAnimationMax = owner.itemAnimationMax;
            // 请记住，从 itemAnimationMax 到 0 的帧数会倒计时
            // 长戟完全伸展的框架。在缩回之前按住此帧
            // 比例因子 （0.34f） 表示动画的最后 34 % 将用于缩回
            int holdOutFrame = (int)(itemAnimationMax * 0.34f);
            if (owner.channel && owner.itemAnimation < holdOutFrame)
            {
                owner.SetDummyItemTime(holdOutFrame); // 这使得射弹在我们拿着它时永远不会死亡（除非我们受到伤害，请参阅 ExampleJoustingLancePlayer）
            }

            // 如果 Jousting Lance 不再使用，则杀死投射物
            if (owner.ItemAnimationEndingOrEnded)
            {
                Projectile.Kill();
                return;
            }

            int itemAnimation = owner.itemAnimation;
            // 伸展和收缩因子 （0 - 1），随着动画的播放，伸展从 0 - 1 变为 1，按住时保持在 1，然后缩回从 0 - 1
            float extension = 1 - Math.Max(itemAnimation - holdOutFrame, 0) / (float)(itemAnimationMax - holdOutFrame);
            float retraction = 1 - Math.Min(itemAnimation, holdOutFrame) / (float)holdOutFrame;

            // 距离以像素为单位
            float extendDist = 24; // 延长时飞出多远
            float retractDist = extendDist / 2; // 缩回时向后飞多远
            float tipDist = 98 + extension * extendDist - retraction * retractDist; // 如果您的骑枪大于或小于标准尺寸，建议更改物品的射击速度而不是此值


            Vector2 center = owner.RotatedRelativePoint(owner.MountedCenter); // 获取所有者的中心。这解释了玩家在骑乘坐骑、坐在椅子上等时被上移或下移
            Projectile.Center = center; // 将射弹的中心设置为拥有者的中心。Projectile.Center 现在实际上是 Jousting Lance 的尖端
            Projectile.position += Projectile.velocity * tipDist; // 弹丸速度包含长枪的方向，将其乘以 tipDist 以定位尖端

            //设置射弹的旋转
            //作为参考，0 是左上角，180 度或 pi 弧度是右下角
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + (float)Math.PI * 3 / 4f;

            //在射弹首次生成时将其淡入
            Projectile.alpha -= 55;
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }

            //加速度尘埃
            float minimumDustVelocity = 6f;
            float movementInLanceDirection = Vector2.Dot(Projectile.velocity.SafeNormalize(Vector2.UnitX * owner.direction), owner.velocity.SafeNormalize(Vector2.UnitX * owner.direction));
            float playerVelocity = owner.velocity.Length();

            if (playerVelocity > minimumDustVelocity && movementInLanceDirection > 0.8f)
            {
                //尘埃生成的几率，实际几率（见下文）是 1 / dustChance，我们通过缩小分母来使玩家移动得越快，机会就越高
                int dustChance = 8;
                if (playerVelocity > minimumDustVelocity + 1f)
                {
                    dustChance = 5;
                }
                if (playerVelocity > minimumDustVelocity + 2f)
                {
                    dustChance = 2;
                }

                //在此处设置您的粉尘类型
                int dustTypeCommon = DustID.GoldFlame;
                int dustTypeRare = DustID.WhiteTorch;
                //此偏移量将影响尘埃的扩散量
                int offset = 4; 
                //根据 dustChance 生成 dust。尘埃生成在 Jousting Lance 的尖端
                if (Main.rand.NextBool(dustChance))
                {
                    int d = Dust.NewDust(Projectile.Center - new Vector2(offset, offset), offset * 2, offset * 2, dustTypeCommon, Projectile.velocity.X * 0.2f + (Projectile.direction * 3), Projectile.velocity.Y * 0.2f, 100, default, 1.2f);
                    Main.dust[d].noGravity = true;
                    Main.dust[d].velocity *= 0.25f;
                    d = Dust.NewDust(Projectile.Center - new Vector2(offset, offset), offset * 2, offset * 2, dustTypeCommon, 0f, 0f, 150, default, 1.4f);
                    Main.dust[d].velocity *= 0.25f;
                }

                if (Main.rand.NextBool(dustChance + 3))
                {
                    Dust.NewDust(Projectile.Center - new Vector2(offset, offset), offset * 2, offset * 2, dustTypeRare, 0f, 0f, 150, default, 1.4f);
                }
            }
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            //这将增加或减少比武长枪的击退，具体取决于玩家的移动速度
            modifiers.Knockback *= Main.player[Projectile.owner].velocity.Length() / 7f;
            //这将增加或减少比武长枪的伤害，具体取决于玩家的移动速度
            modifiers.SourceDamage *= 0.1f + Main.player[Projectile.owner].velocity.Length() / 7f * 0.9f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 v = new Vector2(0, 0);
            //每次迭代，将新生成的射弹旋转相当于圆的 1 / 4 （MathHelper.PiOver4）
            //请记住，泰拉瑞亚中的所有旋转都是基于弧度，而不是度数！
            v = v.RotatedBy(MathHelper.PiOver4);
            //生成一个具有新旋转速度的新射弹，属于原始射弹拥有者。新射弹将继承此射弹的生成源
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<HeliumFlash>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);

            //爆炸声音
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            //火花粒子
            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldFlame, 0f, 0f, 100, default, 3.5f);
                d.noGravity = true;
                d.velocity *= 6f;
                Dust d2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 0f, 0f, 100, default, 1.5f);
                d2.velocity *= 2f;
            }

            for (int j = 0; j < 2; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldFlame, 0f, 0f, 100, default, 3.5f);
                d.noGravity = true;
                d.velocity *= 8f;
                Dust d2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 0f, 0f, 100, default, 1.5f);
                d.velocity *= 4f;
            }
            target.AddBuff(BuffID.Daybreak, 600);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            v = v.RotatedBy(MathHelper.PiOver4);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<HeliumFlash>(), Projectile.damage / 2, Projectile.knockBack = 0, Projectile.owner);

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldFlame, 0f, 0f, 100, default, 3.5f);
                d.noGravity = true;
                d.velocity *= 6f;
                Dust d2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 0f, 0f, 100, default, 1.5f);
                d2.velocity *= 2f;
            }

            for (int j = 0; j < 2; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldFlame, 0f, 0f, 100, default, 3.5f);
                d.noGravity = true;
                d.velocity *= 8f;
                Dust d2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare, 0f, 0f, 100, default, 1.5f);
                d2.velocity *= 4f;
            }
        }
    }
}