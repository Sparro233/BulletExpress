namespace BulletExpress.Projectiles.Horti
{
    public class SunTear : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.AllowsContactDamageFromJellyfish[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.width = 30;
            Projectile.height = 30;

            Projectile.timeLeft = 120;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            float v = Projectile.velocity.ToRotation();
            Projectile.rotation = v + 0.78f;
            Player player = Main.player[Projectile.owner];
            Projectile.velocity *= 0.96f;
        }

        public override Color? GetAlpha(Color drawColor) => Projectile.ai[0] == 1 ? new Color(0, 0, 0, Projectile.alpha) : new Color(255, 255, 255, Projectile.alpha);

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];
            player.Heal(5);
            target.AddBuff(313, 120);
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.BurningFire>(), 120);
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.GardeningHunt>(), 30);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;

            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<Ranged.DaylightExplodes>(), Projectile.damage / 2, Projectile.knockBack = 0, Projectile.owner);

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}