namespace BulletExpress.AmmoPro.Arrow
{
    public class SpectreArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 155;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 400;
            Projectile.penetrate = 8;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.arrow = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            if (Projectile.timeLeft > 80)
            {
                int index = Projectile.FindTargetWithLineOfSight(800);
                if (index >= 0)
                {
                    NPC npc = Main.npc[index];
                    Projectile.velocity += (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 0.8f;
                }
                else
                {
                    if(Projectile.timeLeft < 380)
                    {
                        Projectile.velocity.Y *= 0.99f;
                        Projectile.velocity.Y -= 0.4f;
                    }
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Type].Value;
            var rot = Projectile.rotation + (float)Math.PI / 2f;
            Main.spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition, null, Color.White, rot,
                tex.Size(), Projectile.scale, 0, 0);
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath39, Projectile.position);
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(31, 600);
            SoundEngine.PlaySound(SoundID.NPCDeath39, Projectile.position);
        }
    }
}