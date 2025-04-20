namespace BulletExpress.AmmoPro.Rocket
{
    public class GoldSquareHoleMoney : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //Éäµ¯¶¯»­Ò³Êý
            Main.projFrames[Projectile.type] = 4;
            ProjectileID.Sets.Explosive[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 30;
            Projectile.height = 30;

            Projectile.timeLeft = 200;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            Projectile.ai[0] += 1f;
            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                Projectile.frame = 0;
            }

            if (Main.rand.NextBool(5))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 55, default, 1f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-12, 12), Main.rand.NextFloat(12, -12));
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v, 413, Projectile.damage / 3, Projectile.knockBack, Main.myPlayer, 0, 1);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(72, 600);
        }
    }
}
