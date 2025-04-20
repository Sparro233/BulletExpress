namespace BulletExpress.Projectiles.Geberic
{
    public class MiniSharkron : ModProjectile 
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            //Projectile.aiStyle = ProjAIStyleID.Arrow;
            AIType = ProjectileID.MiniSharkron;

            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 24;
            Projectile.height = 24;
            DrawOriginOffsetY = 0;
            DrawOffsetX = -12;

            Projectile.timeLeft = 600;

            Projectile.friendly = true;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            base.AI();
            float v = Projectile.velocity.ToRotation();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Projectile.rotation = v + 3.14f;

            Projectile.ai[0] += 1f;
            if (++Projectile.frameCounter >= 4)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            //针对单侧垂直
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation += MathHelper.Pi;
            }

            if (Projectile.timeLeft == 600)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath19 with { Volume = 1f }, Projectile.position);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<WaterSpout>(), Projectile.damage, Projectile.knockBack = 0, Projectile.owner);
        }

        public override void OnKill(int timeLeft)
        {
            for (int d = 0; d < 15; ++d)
            {
                int idx = Dust.NewDust(Projectile.Center - Vector2.One * 10f, 50, 50, DustID.Blood, 0f, -2f, 0, default, 1f);
                Dust dust = Main.dust[idx];
                dust.velocity /= 2f;
            }
            if (Main.netMode != NetmodeID.Server)
            {
                int tail = Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Projectile.velocity * 0.8f, 584, 1f);
                Main.gore[tail].timeLeft /= 10;
                int body = Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Projectile.velocity * 0.9f, 585, 1f);
                Main.gore[body].timeLeft /= 10;
                int head = Gore.NewGore(Projectile.GetSource_Death(), Projectile.Center, Projectile.velocity * 1f, 586, 1f);
                Main.gore[head].timeLeft /= 10;
            }
        }
    }
}