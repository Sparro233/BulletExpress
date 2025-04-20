namespace BulletExpress.AmmoPro.Arrow
{
    public class OrichalcumArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 14;
            Projectile.height = 14;

            Projectile.timeLeft = 600;
            Projectile.penetrate = 2;
            Projectile.localNPCHitCooldown = 20;

            Projectile.arrow = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.PiOver2;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 30f && Projectile.penetrate == 2)
            {
                Projectile.ai[0] = 30f;
                Projectile.velocity.Y *= 0.99f;
                Projectile.velocity.Y += 0.1f;
            }
            int index = Projectile.FindTargetWithLineOfSight(1600);
            if (index >= 0 && Projectile.penetrate <= 1)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 10f;
            }
            if (Main.rand.NextBool(20))
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<IDA.Powders.Powder>(), 0f, 0f, 55, default, 1.5f);
                d.velocity.X *= 0.2f;
                d.velocity.Y *= 0.5f;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            var tex = TextureAssets.Projectile[Type].Value;
            var rot = Projectile.rotation + (float)Math.PI / 2f;
            Main.spriteBatch.Draw(tex, Projectile.Center - Main.screenPosition, null, Color.White, rot,
                tex.Size() / 2, Projectile.scale, 0, 0);
            return false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    Player player = Main.player[Projectile.owner];
                    Projectile.tileCollide = false;
                    Projectile.position = player.position + Projectile.velocity * (500f - Projectile.timeLeft);
                }
            }
            for (int i = 0; i < 6; i++)
            {
                //C = 角度, CV = 角向量, Range = 距离, Pos = 位置, off = 执行。
                float C = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(2f, 4f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.ShyPink>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.damage = (int)(Projectile.damage * 0.5f);
            return false;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            Projectile.tileCollide = false;
            Player player = Main.player[Projectile.owner];
            Projectile.position = player.position + Projectile.velocity * (400f - Projectile.timeLeft);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            if (Projectile.penetrate == 1)
            {
                Vector2 v2 = Main.rand.NextVector2CircularEdge(400f, 400f);
                Vector2 vector2 = v2.SafeNormalize(Vector2.UnitY) * 10f;
                Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - vector2 * 20f, vector2, 221, Projectile.damage, 0f, Projectile.owner, 0f, target.Center.Y);
            }
            for (int i = 0; i < 6; i++)
            {
                //C = 角度, CV = 角向量, Range = 距离, Pos = 位置, off = 执行。
                float C = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(2f, 4f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.ShyPink>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
            Projectile.Kill();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.tileCollide = false;
            Player player = Main.player[Projectile.owner];
            Projectile.position = player.position + Projectile.velocity * (400f - Projectile.timeLeft);
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            if (Projectile.penetrate == 1)
            {
                Vector2 v2 = Main.rand.NextVector2CircularEdge(400f, 400f);
                Vector2 vector2 = v2.SafeNormalize(Vector2.UnitY) * 10f;
                Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center - vector2 * 20f, vector2, 221, Projectile.damage, 0f, Projectile.owner, 0f, target.Center.Y);
            }
            for (int i = 0; i < 6; i++)
            {
                //C = 角度, CV = 角向量, Range = 距离, Pos = 位置, off = 执行。
                float C = MathHelper.TwoPi * Main.rand.NextFloat(0f, 1f);
                Vector2 CV = C.ToRotationVector2();

                float Range = Main.rand.NextFloat(2f, 4f);
                Vector2 off = CV * Range;

                off.Y *= (float)Projectile.height / Projectile.width;
                Vector2 Pos = Projectile.Center + off;
                Dust d = Dust.NewDustPerfect(Pos, ModContent.DustType<IDA.Powders.ShyPink>(), CV * Main.rand.NextFloat(2f, 4f));
                d.velocity *= 0.2f;
                d.scale *= 2f;
                d.customData = true;
                d.noGravity = true;
            }
            Projectile.damage = (int)(Projectile.damage * 0.8f);
        }
    }
}