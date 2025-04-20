namespace BulletExpress.Projectiles.Horti
{
    public class TimeEnd : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 55;
            Projectile.width = 12;
            Projectile.height = 12;
            DrawOriginOffsetY = -6;

            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.02f;

            Projectile.ai[0]++;
            if (Projectile.ai[0] > 20f && Projectile.timeLeft >= 420)
            {
                Projectile.velocity *= 0.93f;
            }

            if (Projectile.ai[0] > 40f && Projectile.timeLeft >= 420)
            {
                Projectile.velocity *= 0.93f;
                int index = Projectile.FindTargetWithLineOfSight(600);
                if (index >= 0)
                {
                    NPC npc = Main.npc[index];
                    Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 20f;
                }
            }

            if (Projectile.timeLeft <= 420)
            {
                Projectile.velocity.Y += 0.3f;
            }
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            target.AddBuff(ModContent.BuffType<IDA.Buffs.Flog.ENDFlog>(), 120);
            target.AddBuff(ModContent.BuffType<IDA.Buffs.KillTheSoCalledGods>(), 600);

            for (int j = 0; j < 2; j++)
            {
                Vector2 v2 = Main.rand.NextVector2CircularEdge(400f, 400f);
                Vector2 vector2 = v2.SafeNormalize(Vector2.UnitY) * 12f;
                Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - vector2 * 20f, vector2, ProjectileType<END>(), Projectile.damage, 0f, Projectile.owner, 0f, target.Center.Y);
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.MapleLeave>(), 0f, 0f, 155, default, 1.8f);
                d.velocity *= 1f;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}