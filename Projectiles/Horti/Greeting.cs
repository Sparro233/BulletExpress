namespace BulletExpress.Projectiles.Horti
{
    public class Greeting : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //¹¥»÷Ë®Ä¸´¥µç
            ProjectileID.Sets.AllowsContactDamageFromJellyfish[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = ModContent.GetInstance<BulletExpress.HortiDamage>();
            Projectile.width = 30;
            Projectile.height = 30;

            Projectile.timeLeft = 90;
            Projectile.penetrate = 1;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            float v = Projectile.velocity.ToRotation();
            Projectile.rotation = v + 3.92f;
            Player player = Main.player[Projectile.owner];
            Projectile.velocity *= 0.96f;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Type].Value;
            var rot = Projectile.rotation + (float)Math.PI / 2f;
            Main.spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition, null, Color.White, rot,
                tex.Size() / 2f, Projectile.scale, 0, 0);
            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 Velocity = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Velocity, ModContent.ProjectileType<Ranged.DaylightExplodes>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);

            Player player = Main.player[Projectile.owner];
            player.Heal(5);
            target.AddBuff(313, 120);
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.BurningFire>(), 120);
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.GardeningHunt>(), 30);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}