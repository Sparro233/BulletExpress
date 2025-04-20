namespace BulletExpress.AmmoPro.Bullet
{
    public class HorizonBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;

            Projectile.timeLeft = 200;
            Projectile.extraUpdates = 2;
            Projectile.penetrate = 3;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Type].Value;
            var rot = Projectile.rotation + (float)Math.PI / 2f;
            Main.spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition, null, Color.White, rot,
                tex.Size() / 2f, Projectile.scale, 0, 0);
            return false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Vector2 v = new Vector2(0, -20);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<HorizonTearI>(), Projectile.damage * 4, Projectile.knockBack, Projectile.owner);

            Vector2 v1 = new Vector2(0, 20);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v1, ModContent.ProjectileType<HorizonTearI>(), Projectile.damage * 4, Projectile.knockBack, Projectile.owner);

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

            for (int i = 0; i < 4; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 0, default, 1.2f);
                Vector2 vI = Projectile.velocity;
                Vector2 vII = vI.RotatedByRandom(MathHelper.ToRadians(15));
                vII *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = vII;
            }
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Vector2 v = new Vector2(-30, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<HorizonTear>(), Projectile.damage * 3, Projectile.knockBack, Projectile.owner);

            Vector2 v1 = new Vector2(30, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v1, ModContent.ProjectileType<HorizonTear>(), Projectile.damage * 3, Projectile.knockBack, Projectile.owner);

            for (int i = 0; i < 4; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 0, default, 1.2f);
                Vector2 vI = Projectile.velocity;
                Vector2 vII = vI.RotatedByRandom(MathHelper.ToRadians(15));
                vII *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = vII;
            }
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<IDA.Buffs.KillTheSoCalledGods>(), 600);

            Vector2 v = new Vector2(-30, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<HorizonTear>(), Projectile.damage * 3, Projectile.knockBack, Projectile.owner);

            Vector2 v1 = new Vector2(30, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v1, ModContent.ProjectileType<HorizonTear>(), Projectile.damage * 3, Projectile.knockBack, Projectile.owner);

            for (int i = 0; i < 4; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 0, default, 1.2f);
                Vector2 vI = Projectile.velocity;
                Vector2 vII = vI.RotatedByRandom(MathHelper.ToRadians(15));
                vII *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = vII;
            }
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);
        }
    }
}