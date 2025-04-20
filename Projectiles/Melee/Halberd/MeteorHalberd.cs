namespace BulletExpress.Projectiles.Melee.Halberd
{
    public class MeteorHalberd : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.DismountsPlayersOnHit[Type] = true;
            ProjectileID.Sets.NoMeleeSpeedVelocityScaling[Type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.alpha = 255;
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.light = 0.5f;

            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;

            Projectile.netImportant = true;
            Projectile.ownerHitCheck = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.hide = true;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float rotationFactor = Projectile.rotation + (float)Math.PI / 4f;
            float scaleFactor = 95f;
            float widthMultiplier = 23f;
            float collisionPoint = 0f;

            Rectangle lanceHitboxBounds = new Rectangle(0, 0, 300, 300);

            lanceHitboxBounds.X = (int)Projectile.position.X - lanceHitboxBounds.Width / 2;
            lanceHitboxBounds.Y = (int)Projectile.position.Y - lanceHitboxBounds.Height / 2;

            Vector2 hitLineEnd = Projectile.Center + rotationFactor.ToRotationVector2() * scaleFactor;

            if (lanceHitboxBounds.Intersects(targetHitbox)
                && Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, hitLineEnd, widthMultiplier * Projectile.scale, ref collisionPoint))
            {
                return true;
            }
            return false;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;

            Texture2D texture = TextureAssets.Projectile[Type].Value;

            Rectangle sourceRectangle = texture.Frame(1, Main.projFrames[Type], frameY: Projectile.frame);

            Vector2 origin = Vector2.Zero;

            float rotation = Projectile.rotation;
            if (Projectile.direction > 0)
            {
                rotation -= (float)Math.PI / 2f;
                origin.X += sourceRectangle.Width;
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            Vector2 position = new(Projectile.Center.X, Projectile.Center.Y - Main.player[Projectile.owner].gfxOffY);
            Color drawColor = Projectile.GetAlpha(lightColor);

            Main.EntitySpriteDraw(texture,
                position - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, drawColor, rotation, origin, Projectile.scale, spriteEffects, 0);
            return false;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            Projectile.direction = owner.direction;
            owner.heldProj = Projectile.whoAmI;

            int itemAnimationMax = owner.itemAnimationMax;

            int holdOutFrame = (int)(itemAnimationMax * 0.34f);
            if (owner.channel && owner.itemAnimation < holdOutFrame)
            {
                owner.SetDummyItemTime(holdOutFrame); 
            }

            if (owner.ItemAnimationEndingOrEnded)
            {
                Projectile.Kill();
                return;
            }

            int itemAnimation = owner.itemAnimation;

            float extension = 1 - Math.Max(itemAnimation - holdOutFrame, 0) / (float)(itemAnimationMax - holdOutFrame);
            float retraction = 1 - Math.Min(itemAnimation, holdOutFrame) / (float)holdOutFrame;

            float extendDist = 24;
            float retractDist = extendDist / 2;
            float tipDist = 98 + extension * extendDist - retraction * retractDist;

            Vector2 center = owner.RotatedRelativePoint(owner.MountedCenter);
            Projectile.Center = center;
            Projectile.position += Projectile.velocity * tipDist;

            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + (float)Math.PI * 3 / 4f;

            Projectile.alpha -= 40;
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }

            float minimumDustVelocity = 6f;

            float movementInLanceDirection = Vector2.Dot(Projectile.velocity.SafeNormalize(Vector2.UnitX * owner.direction), owner.velocity.SafeNormalize(Vector2.UnitX * owner.direction));

            float playerVelocity = owner.velocity.Length();

            if (playerVelocity > minimumDustVelocity && movementInLanceDirection > 0.8f)
            {
                int dustChance = 8;
                if (playerVelocity > minimumDustVelocity + 1f)
                {
                    dustChance = 5;
                }
                if (playerVelocity > minimumDustVelocity + 2f)
                {
                    dustChance = 2;
                }
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.Knockback *= Main.player[Projectile.owner].velocity.Length() / 7f;
            modifiers.SourceDamage *= 0.1f + Main.player[Projectile.owner].velocity.Length() / 7f * 0.9f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 600);
        }
    }
}