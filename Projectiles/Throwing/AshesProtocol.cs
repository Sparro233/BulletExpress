namespace BulletExpress.Projectiles.Throwing
{
    public abstract class AshesProtocol : ModProjectile, ILocalizedModType
    {
        public override string Texture => "BulletExpress/Projectiles/Throwing/AshesProtocol";
        public new string LocalizationCategory => "Projectiles.Throwing";
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.FallingBlockDoesNotFallThroughPlatforms[Type] = true;
            ProjectileID.Sets.ForcePlateDetection[Type] = true;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
        }
    }

    public class AshesProtocolA : AshesProtocol
    {
        public new string LocalizationCategory => "Projectiles.Throwing";
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ProjectileID.Sets.FallingBlockTileItem[Type] = new(ModContent.TileType<IDA.Tiles.AshesCourier>(), ModContent.ItemType<IDB.Materials.Courier.AshesCourier>());
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 30;
            Projectile.height = 30;
            DrawOriginOffsetY = -6;

            Projectile.timeLeft = 1200;
            Projectile.penetrate = -1;

            Projectile.friendly = true;
            Projectile.tileCollide = true;

            Projectile.CloneDefaults(ProjectileID.EbonsandBallGun);
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }

    public class AshesProtocolB : AshesProtocol
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            ProjectileID.Sets.FallingBlockTileItem[Type] = new(ModContent.TileType<IDA.Tiles.AshesCourier>());
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EbonsandBallFalling);
            AIType = ProjectileID.EbonsandBallFalling; 
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
        }
    }
}