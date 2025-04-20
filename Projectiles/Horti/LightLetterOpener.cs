namespace BulletExpress.Projectiles.Horti
{
    public class LightLetterOpener : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.width = 12;
            Projectile.height = 12;
            DrawOriginOffsetY = -6;

            Projectile.timeLeft = 60;

            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.02f;

            Projectile.ai[0]++;
            if (Projectile.ai[0] > 20f)
            {
                Projectile.velocity *= 0.93f;
            }
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<IDA.Buffs.Flog.FlogI>(), 120);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            
            for (int j = 0; j < 1; j++)
            {
                Vector2 v2 = Main.rand.NextVector2CircularEdge(400f, 400f);
                Vector2 vector2 = v2.SafeNormalize(Vector2.UnitY) * 12f;
                Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - vector2 * 20f, vector2, ProjectileType<LightTear>(), Projectile.damage / 2, 0f, Projectile.owner, 0f, target.Center.Y);
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int j = 0; j < 6; j++)
            {
                Dust newDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 15, default, 1f);
                newDust.velocity *= 1f;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}