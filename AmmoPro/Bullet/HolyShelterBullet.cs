namespace  BulletExpress.AmmoPro.Bullet
{
	public class HolyShelterBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.light = 0.2f;

            Projectile.timeLeft = 400;
            Projectile.extraUpdates = 2;
            Projectile.penetrate = 3;
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
            if (Main.rand.NextBool(20))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightVI>(), 0f, 0f, 55, default, 3f);
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
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.Bless.HolyBless>(), 120);

            for (int i = 0; i < 8; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightVI>(), 0f, 0f, 0, default, 1.5f);
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(15));
                v2 *= 1f - Main.rand.NextFloat(0.9f);
                d.velocity = v2;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.Bless.HolyBless>(), 120);

            for (int i = 0; i < 8; i++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightVI>(), 0f, 0f, 0, default, 1.5f);
                Vector2 v = Projectile.velocity;
                Vector2 v2 = v.RotatedByRandom(MathHelper.ToRadians(15));
                v2 *= 1f - Main.rand.NextFloat(0.9f); 
                d.velocity = v2;
            }
        }
    }
}