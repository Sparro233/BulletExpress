namespace BulletExpress.Projectiles.Horti
{
    public class SpectreLetterOpener : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 115;
            Projectile.width = 12;
            Projectile.height = 12;
            DrawOffsetX = -6;

            Projectile.timeLeft = 600;
            Projectile.penetrate = 3;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
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
                int index = Projectile.FindTargetWithLineOfSight(800);
                if (index >= 0)
                {
                    NPC npc = Main.npc[index];
                    Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 32f;
                }
            }
            if (Projectile.timeLeft <= 420)
            {
                Projectile.velocity.Y += 0.3f;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Type].Value;
            var rot = Projectile.rotation + (float)Math.PI / 2f;
            Main.spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition, null, Color.White, rot,
                tex.Size() / 2f, Projectile.scale, 0, 0);
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }

        public override void OnKill(int timeLeft)
        {
            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 15, default, 1f);
                d.velocity *= 3f;
            }
        }
    }
}