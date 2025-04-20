namespace BulletExpress.Projectiles.Energy
{
    public class LightRain : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Energy";
        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.alpha = 250;
            Projectile.width = 2;
            Projectile.height = 2;

            Projectile.timeLeft = 600;

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

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(309, 300);
            Main.player[Projectile.owner].AddBuff(308, 600);
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.Bless.JyoratBless>(), 600);

            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(309, 600);
            Main.player[Projectile.owner].AddBuff(308, 600);
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.Bless.JyoratBless>(), 600);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }

        public override void OnKill(int timeLeft)
        {
            for (int j = 0; j < 2; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.LightVI>(), 0f, 0f, 15, default, 1f);
                d.velocity *= 1f;
            }
        }
    }
}