namespace BulletExpress.AmmoPro.Dart
{
	public class PotencyCrystalDart : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 1200;
            Projectile.extraUpdates = 2;
            Projectile.penetrate = 8;
            Projectile.localNPCHitCooldown = 20;
            
            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;            
            if (Projectile.ai[0] >= 30f)
            {
                Projectile.ai[0] = 60f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
            }
            if (Projectile.timeLeft % 50 == 0 && Projectile.penetrate >= 2)
            {
                Projectile.penetrate -= 1;
                Projectile split = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<PotencyCrystalDartI>(), Projectile.damage / 2, Projectile.knockBack, Main.myPlayer, 0, 1);
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
            Projectile child = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, v, ProjectileID.CrystalDart, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 1);
            Projectile.penetrate--;
            if (Projectile.penetrate <= 2)
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
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            return false;
        }
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.damage = (int)(Projectile.damage * 0.8f);
        }
    }
}