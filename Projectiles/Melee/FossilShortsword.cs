namespace BulletExpress.Projectiles.Melee
{
    public class FossilShortsword : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        public const int FadeInDuration = 7;
        public const int FadeOutDuration = 4;
        public const int TotalDuration = 16;
        public float CollisionWidth => 10f * Projectile.scale;

        public int Timer
        {
            get => (int)Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 32;
            Projectile.height = 32;

            Projectile.timeLeft = 12;
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = 10;

            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        public void FadeInAndOut()
        {
            if (Projectile.ai[0] <= 50f)
            {
                Projectile.alpha -= 25;
                if (Projectile.alpha < 100)
                    Projectile.alpha = 100;

                return;
            }
            Projectile.alpha += 25;
            if (Projectile.alpha > 255)
                Projectile.alpha = 255;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            Projectile.spriteDirection = (Vector2.Dot(Projectile.velocity, Vector2.UnitX) >= 0f).ToDirectionInt();
            Player player = Main.player[Projectile.owner];
            Timer += 1;
            if (Timer >= TotalDuration)
            {
                Projectile.Kill();
                return;
            }
            else
            {
                player.heldProj = Projectile.whoAmI;
            }
            Projectile.Opacity = Utils.GetLerpValue(0f, FadeInDuration, Timer, clamped: true) * Utils.GetLerpValue(TotalDuration, TotalDuration - FadeOutDuration, Timer, clamped: true);

            Vector2 Center = player.RotatedRelativePoint(player.MountedCenter, reverseRotation: false, addGfxOffY: false);
            Projectile.Center = Center + Projectile.velocity * (Timer - 1f);

            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {
            const int HalfSpriteWidth = 32 / 2;
            const int HalfSpriteHeight = 32 / 2;

            int Width = Projectile.width / 2;
            int Height = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -(HalfSpriteWidth - Width);
            DrawOriginOffsetY = -(HalfSpriteHeight - Height);
        }

        public override bool ShouldUpdatePosition()
        {
            return false;
        }
    }
}