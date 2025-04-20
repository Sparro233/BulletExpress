namespace BulletExpress.Projectiles.Horti
{
    public class HeavenlyWing : ModProjectile
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

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.velocity.X * 0.02f;

            Projectile.ai[0]++;
            if (Projectile.ai[0] > 20f && Projectile.timeLeft >= 420)
            {
                Projectile.velocity *= 0.93f;
            }

            if (Projectile.ai[0] > 60f && Projectile.timeLeft >= 420)
            {
                int index = Projectile.FindTargetWithLineOfSight(600);
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
            target.AddBuff(ModContent.BuffType<IDA.Buffs.Flog.LightMark>(), 120);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            if (Projectile.penetrate == 1)
            {
                for (int j = 0; j < 1; j++)
                {
                    Vector2 v2 = Main.rand.NextVector2CircularEdge(400f, 400f);
                    Vector2 vector2 = v2.SafeNormalize(Vector2.UnitY) * 12f;
                    Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - vector2 * 20f, vector2, ProjectileType<DrTear>(), Projectile.damage / 2, 0f, Projectile.owner, 0f, target.Center.Y);
                }
            }

            for (int j = 1; j < 3; j++)
            {
                Dust newDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 15, default, 0.8f);
                newDust.velocity *= 1f;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}