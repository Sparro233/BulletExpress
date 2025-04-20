namespace BulletExpress.Projectiles.Ranged
{
    public class TitaniumPetalsI : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetStaticDefaults()
        {
            //Éäµ¯¶¯»­Ò³Êý
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 8;
            Projectile.height = 8;

            Projectile.timeLeft = 360;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X * 0.1f;
            Projectile.velocity.Y *= 0.99f;
            Projectile.velocity.Y += 0.2f;
            Projectile.ai[0] += 1f;
            if (++Projectile.frameCounter >= 2)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            int index = Projectile.FindTargetWithLineOfSight(520);
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity += (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 1f;
            }
            if (Projectile.timeLeft % 10 == 0)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightV>(), 0f, 0f, 55, default, 1.8f);
                d.velocity *= 0f;
                d.noGravity = true;
            }
        }
    }
}
