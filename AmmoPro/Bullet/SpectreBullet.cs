namespace  BulletExpress.AmmoPro.Bullet
{
	public class SpectreBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 155;
            Projectile.width = 2;
            Projectile.height = 2;

            Projectile.timeLeft = 400;
            Projectile.extraUpdates = 1;
            Projectile.penetrate = 8;
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
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            /*Projectile.ai[0]++;
            if (Projectile.ai[0] > 15f)
            {
                Projectile.ai[0] = 15f;
            }*/
            if (Projectile.timeLeft < 390)
            {
                if (Projectile.timeLeft > 80)
                {
                    int index = Projectile.FindTargetWithLineOfSight(240);
                    if (index >= 0)
                    {
                        NPC npc = Main.npc[index];
                        Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 18f;
                    }
                }
            }
            if (Main.rand.NextBool(20))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 55, default, 1.2f);
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

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath39, Projectile.position);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(31, 600);
            SoundEngine.PlaySound(SoundID.NPCDeath39, Projectile.position);
            Projectile.damage = (int)(Projectile.damage * 0.8f);
        }
    }
}