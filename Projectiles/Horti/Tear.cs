namespace BulletExpress.Projectiles.Horti
{
    public class Tear : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.AllowsContactDamageFromJellyfish[Type] = true;//¹¥»÷Ë®Ä¸´¥µç
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.width = 30;
            Projectile.height = 30;

            Projectile.timeLeft = 60;
            Projectile.penetrate = 1;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            float v = Projectile.velocity.ToRotation();
            Projectile.rotation = v + 0.78f;
            Player player = Main.player[Projectile.owner];
            Projectile.velocity *= 0.93f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<Horti.Slash>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);

            Player player = Main.player[Projectile.owner];
            player.Heal(5);
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.GardeningHunt>(), 30);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }
    }
}