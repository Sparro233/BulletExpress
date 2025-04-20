namespace BulletExpress.AmmoPro.Arrow
{
    public class HorizonArrow : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 400;
            Projectile.penetrate = 2;
            Projectile.localNPCHitCooldown = 20;

            Projectile.arrow = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.ai[0] = 30f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.2f;
            }
            int index = Projectile.FindTargetWithLineOfSight(180);
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity += (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 1f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int j = 0; j < 2; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.ShyPink>(), 0f, 0f, 55, default, 2f);
                Projectile.velocity.Y -= 0.1f;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.Kill();
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.velocity = (target.Center - Projectile.Center) * 0.8f;
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.Bless.HolyBless>(), 120);
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            //基于目标增量中心的更改速度（实体中心之间的差异）
            Projectile.velocity = (target.Center - Projectile.Center) * 0.8f;
            for (int i = 0; i < 1; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-5, -4));
                Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v, ModContent.ProjectileType<Projectiles.Ranged.Turbulence>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 1);
            }

            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.ShyPink>(), 0f, 0f, 55, default, 3f);
            Projectile.velocity.Y -= 0.2f;
        }
    }
}