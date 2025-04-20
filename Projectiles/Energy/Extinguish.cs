namespace BulletExpress.Projectiles.Energy
{
    public class Extinguish : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Energy";
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.EnergyDamage>();
            Projectile.alpha = 255;
            Projectile.width = 3;
            Projectile.height = 3;

            Projectile.timeLeft = 90;
            Projectile.penetrate = -1;
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
            Projectile.rotation += Projectile.velocity.X * 0.1f;

            Projectile.velocity *= 0.99f;

            Projectile.alpha -= 10;
            if (Projectile.alpha < 5)
            {
                Projectile.alpha = 5;
            }

            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }

            int index = Projectile.FindTargetWithLineOfSight(160);
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity += (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 1.1f;
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

        public void FadeInAndOut()
        {
            if (Projectile.ai[0] <= 1f)
            {
                Projectile.alpha += 10;
                if (Projectile.alpha < 250)
                    Projectile.alpha = 250;

                return;
            }

            Projectile.alpha -= 10;
            if (Projectile.alpha > 250)
                Projectile.alpha = 250;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<IDA.Buffs.KillTheSoCalledGods>(), 600);

            Projectile.damage = (int)(Projectile.damage * 0.7f);
            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 100, default, 1f);
                d.noGravity = true;
                d.velocity *= 2f;
            }
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ProjectileID.MagicMissile, Projectile.damage, Projectile.knockBack, Projectile.owner);

            for (int j = 0; j < 3; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, 15, 0f, 0f, 100, default, 1.2f);
                d.noGravity = true;
                d.velocity *= 4f;
            }   
        }
    }
}