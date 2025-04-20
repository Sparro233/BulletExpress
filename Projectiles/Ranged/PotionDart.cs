namespace BulletExpress.Projectiles.Ranged
{
    public class PotionDart : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 24;
            Projectile.height = 24;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 2;

            Projectile.friendly = true;
            Projectile.hostile = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;

            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 10f)
            {
                Projectile.hostile = true;
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.HealOrFatal>(), 600);
            for (int j = 0; j < 4; j++)
            {
                Dust D = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 100, default, 1f);
                D.noGravity = true;
                D.velocity *= 2f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<IDA.Buffs.HealOrFatal>(), 600);
            for (int j = 0; j < 4; j++)
            {
                Dust D = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 100, default, 1f);
                D.noGravity = true;
                D.velocity *= 2f;
            }
        }
    }
}