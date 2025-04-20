namespace BulletExpress.AmmoPro.Bullet
{
	public class MapleLeaveBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;

            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 2;
            Projectile.penetrate = 6;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            if (Main.rand.NextBool(5))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.MapleLeave>(), 0f, 0f, 55, default, 1f);
                d.velocity *= 0f; 
                d.noGravity = true;
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

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Vector2 v = new Vector2(Main.rand.NextFloat(-8, 8), Main.rand.NextFloat(8, -8));
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<Projectiles.Ranged.MapleLeave>(), Projectile.damage, Projectile.knockBack = 0, Projectile.owner);
            Projectile.penetrate--;
            if (Projectile.penetrate < 5)
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
            SoundEngine.PlaySound(SoundID.Grass, Projectile.position);
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(4, -4));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<Projectiles.Ranged.MapleLeave>(), Projectile.damage, Projectile.knockBack = 0, Projectile.owner);

                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.MapleLeave>(), 0f, 0f, 55, default, 1f);
                d.velocity *= 3f;
                d.noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(4, -4));
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<Projectiles.Ranged.MapleLeave>(), Projectile.damage, Projectile.knockBack = 0, Projectile.owner);

                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.MapleLeave>(), 0f, 0f, 55, default, 1f);
                d.velocity *= 3f;
                d.noGravity = true;
            }

            Projectile.damage = (int)(Projectile.damage * 0.8f);
        }
    }
}