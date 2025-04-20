namespace BulletExpress.AmmoPro.Arrow
{
    public class GooSArrow : ModProjectile
    { 
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 40;
            Projectile.penetrate = 3;
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
            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Vector2 v = Projectile.velocity;
            Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
            v2 *= 1f - Main.rand.NextFloat(0.2f);
            Projectile split = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v2, ModContent.ProjectileType<GooSMania>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 0);
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Feather>(), 0f, 0f, 55, default, 2f);
            d.noGravity = true;
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<IDA.Buffs.KillTheSoCalledGods>(), 600);
            Vector2 v = Projectile.velocity;
            Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(40));
            v2 *= 1f - Main.rand.NextFloat(0.2f);
            Projectile split = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v2, ModContent.ProjectileType<GooSMania>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 0);
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Feather>(), 0f, 0f, 55, default, 2f);
            d.noGravity = true;
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<GooSFeather>(), Projectile.damage * 4, Projectile.knockBack, Projectile.owner);
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Feather>(), 0f, 0f, 100, default, 3f);
            d.velocity *= 1f;
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);
        }
    }
}