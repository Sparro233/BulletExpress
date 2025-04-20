namespace BulletExpress.Projectiles.Horti
{
    public class END : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.AllowsContactDamageFromJellyfish[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.width = 30;
            Projectile.height = 30;

            Projectile.timeLeft = 200;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            float v = Projectile.velocity.ToRotation();
            Player player = Main.player[Projectile.owner];
            Projectile.rotation = v + 0.78f;
            Projectile.velocity *= 0.93f;

            if (Main.mouseRight)
            {
                Vector2 unit = Vector2.Normalize(Main.MouseWorld - player.Center);
                float rotaion = unit.ToRotation();
                player.itemTime = 10;
                player.itemAnimation = 10;
                player.direction = Main.MouseWorld.X < player.Center.X ? -1 : 1;
                player.itemRotation = (float)Math.Atan2(rotaion.ToRotationVector2().Y * player.direction, rotaion.ToRotationVector2().X * player.direction);
                Vector2 unit2 = Vector2.Normalize(Main.MouseWorld - Projectile.Center);

                if (Vector2.Distance(Projectile.Center, Main.MouseWorld) < 28)
                {
                    Projectile.velocity *= 0.5f;
                    Projectile.rotation += 0.25f;
                    Projectile.Center = Main.MouseWorld;
                }
                else
                {
                    Projectile.velocity = unit2 * 28;
                }
            }
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<Horti.Slash>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);

            Player player = Main.player[Projectile.owner];
            player.Heal(5);
            target.AddBuff(ModContent.BuffType<IDA.Buffs.Flog.ENDFlog>(), 120);
            target.AddBuff(ModContent.BuffType<IDA.Buffs.KillTheSoCalledGods>(), 600);

            Vector2 v = Main.rand.NextVector2CircularEdge(400f, 400f);
            Vector2 I = v.SafeNormalize(Vector2.UnitY) * 12f;
            Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - I * 20f, I, ProjectileType<StormTear>(), Projectile.damage, 0f, Projectile.owner, 0f, target.Center.Y);

            Vector2 v2 = Main.rand.NextVector2CircularEdge(400f, 400f);
            Vector2 II = v2.SafeNormalize(Vector2.UnitY) * 12f;
            Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - II * 20f, II, ProjectileType<MagicTear>(), Projectile.damage, 0f, Projectile.owner, 0f, target.Center.Y);

            Vector2 v3 = Main.rand.NextVector2CircularEdge(400f, 400f);
            Vector2 III = v3.SafeNormalize(Vector2.UnitY) * 12f;
            Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - III * 20f, III, ProjectileType<LightTear>(), Projectile.damage, 0f, Projectile.owner, 0f, target.Center.Y);
        }

        public override void OnKill(int timeLeft)
        {
            for (int j = 0; j < 2; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.MapleLeave>(), 0f, 0f, 155, default, 1.8f);
                d.velocity *= 1f;
            }
        }
    }
}