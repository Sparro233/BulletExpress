namespace BulletExpress.Projectiles.Horti
{
    public class KristiaTear : ModProjectile
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
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<Horti.Slash>(), Projectile.damage, Projectile.knockBack, Projectile.owner);

            target.AddBuff(ModContent.BuffType<IDA.Buffs.Flog.LightMark>(), 120);
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.GardeningHunt>(), 30);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            
            for (int j = 1; j < 2; j++)
            {
                Vector2 v2 = Main.rand.NextVector2CircularEdge(400f, 400f);
                Vector2 vector2 = v2.SafeNormalize(Vector2.UnitY) * 12f;
                Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - vector2 * 20f, vector2, ProjectileType<DrTear>(), Projectile.damage / 2, 0f, Projectile.owner, 0f, target.Center.Y);
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int j = 1; j < 2; j++)
            {
                Dust newDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Light>(), 0f, 0f, 15, default, 1f);
                newDust.velocity *= 1f;
            }
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
    }
}