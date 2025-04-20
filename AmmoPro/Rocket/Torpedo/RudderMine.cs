namespace BulletExpress.AmmoPro.Rocket.Torpedo
{
    public class RudderMine : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //在不移动和“武装”时造成三倍伤害。
            //ProjectileID.Sets.IsAMineThatDealsTripleDamageWhenStationary[Type] = true;

            //这个系列已经为我们处理了一些事情：
            //在 PVP 中与 NPC 或玩家碰撞时，将 timeLeft 设置为 3 和弹丸方向（以便炸药可以引爆）。
            //炸药也会从 Shimmer 的顶部反弹，在接触 Shimmer 的底部或侧面时引爆而不会造成爆炸伤害，并对 For the Worthy 世界中的其他玩家造成伤害。
            ProjectileID.Sets.Explosive[Type] = true;
            //对玩家造成的伤害在原版中不会随难度而变化。
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 10;
            Projectile.height = 10;
            DrawOffsetX = -6;
            DrawOriginOffsetY = -6;

            Projectile.timeLeft = 1800;
            Projectile.penetrate = 1;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X * 0.1f; //根据地雷的移动方向旋转地雷。

            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }

            Projectile.velocity.Y += 0.2f; //让它掉下来。请记住，正 Y 为下行。
            Projectile.velocity *= 0.97f; //让它慢下来。

            int index = Projectile.FindTargetWithLineOfSight(160);//有敌人的时候追上去
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
                Projectile.velocity = (npc.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 16f;
                Projectile.timeLeft = 60;
            }

            //如果 timeLeft 为 <= 3，则引爆地雷。
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.PrepareBombToBlow();
            }
            else
            {
                //如果地雷没有移动或几乎没有移动，请使其几乎不可见。
                if (Projectile.velocity.X > -0.2f && Projectile.velocity.X < 0.2f && Projectile.velocity.Y > -0.2f && Projectile.velocity.Y < 0.2f)
                {
                    Projectile.alpha += 2;
                    if (Projectile.alpha > 200)
                    {
                        Projectile.alpha = 200;
                    }
                }
                //否则，使其不透明并生成一堆烟尘。
                else
                {
                    Projectile.alpha = 0;
                    Dust newdust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, 0f, 0f, 55, default, 1f);
                    newdust.velocity *= 0f;
                }
            }

            //如果矿井移动得非常缓慢，就让它完全停止。
            if (Projectile.velocity.X > -0.1f && Projectile.velocity.X < 0.1f)
            {
                Projectile.velocity.X = 0f;
            }

            if (Projectile.velocity.Y > -0.1f && Projectile.velocity.Y < 0.1f)
            {
                Projectile.velocity.Y = 0f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //从瓷砖上弹开。
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = oldVelocity.X * -0.4f;
            }

            if (Projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 0.7f)
            {
                Projectile.velocity.Y = oldVelocity.Y * -0.4f;
            }
            //返回 false，这样弹丸就不会被杀死。如果你确实希望你的射弹在接触图格时爆炸，请不要在此处返回 true。
            //如果返回 true，则射弹将在不调整大小的情况下死亡（无爆炸半径）。
            //相反，请像 Example Rocket Projectile 一样设置 'Projectile.timeLeft = 3;'。
            return false;
        }

        public override void PrepareBombToBlow()
        {
            Projectile.tileCollide = false; //这很重要，否则如果地雷在斜坡上爆炸，爆炸就会在错误的地方。
            Projectile.alpha = 255; //使地雷不可见。
            //调整弹丸的碰撞箱大小以适应爆炸的 “半径”。
            //火箭 I：128，火箭 III：200，迷你核火箭：250
            //测量值以像素为单位，因此 128 / 16 = 8 个图块。
            Projectile.Resize(128, 128);
            //设置爆炸的击退。
            //火箭 I：8f，火箭 III：10f，迷你核火箭：12f
            Projectile.knockBack = 8f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int j = 0; j < 4; j++)
            {
                Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, 0f, 0f, 100, default, 3f);
                d.noGravity = true;
                d.velocity *= 4f;
            }
        }

        public override void OnKill(int timeLeft)
        {
            //播放爆炸声。
            //SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            //再次调整射弹的大小，以便从中间生成爆炸、灰尘和血腥。
            //火箭 I：22，火箭 III：80，迷你核弹火箭：50
            Projectile.Resize(80, 80);

            Vector2 v = new Vector2(0, 0);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<RTBoom>(), Projectile.damage * 6, Projectile.knockBack = 0, Projectile.owner);
            
            Dust d = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.AncientLight, 0f, 0f, 200, default, 4f);
            SoundEngine.PlaySound(SoundID.Item178, Projectile.position);
        }
    }
}