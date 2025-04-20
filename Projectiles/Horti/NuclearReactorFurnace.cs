namespace BulletExpress.Projectiles.Horti
{
    public class NuclearReactorFurnace : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.width = 12;
            Projectile.height = 12;
            DrawOffsetX = -6;

            Projectile.timeLeft = 600;

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
                int index = Projectile.FindTargetWithLineOfSight(320);
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
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            v = v.RotatedBy(MathHelper.PiOver4);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<Ranged.DaylightExplodes>(), Projectile.damage / 2, Projectile.knockBack = 0, Projectile.owner);

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}