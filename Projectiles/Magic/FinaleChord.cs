namespace BulletExpress.Projectiles.Magic
{
    public class FinaleChord : ModProjectile, ILocalizedModType
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.width = 180;
            Projectile.height = 96;
            DrawOriginOffsetY = 6;

            Projectile.penetrate = 20;
            Projectile.localNPCHitCooldown = 20;
            //防止射弹时间耗尽前死亡
            Projectile.stopsDealingDamageAfterPenetrateHits = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ownerHitCheck = true;
        }

        public override void AI()
        {
            base.AI();
            int index = Projectile.FindTargetWithLineOfSight(600);
            if (index >= 0)
            {
                NPC npc = Main.npc[index];
            }
            Player player = Main.player[Projectile.owner];

            //框架和废话
            Projectile.frameCounter++;
            if (Projectile.frameCounter % 7 == 0)
            {
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.Kill();
            }

            //创建空闲光和灰尘。
            Vector2 origin = Projectile.Center + Projectile.velocity * 3f;
            Lighting.AddLight(origin, 0f, 1.5f, 0.1f);

            Vector2 playerRotatedPoint = player.RotatedRelativePoint(player.MountedCenter, true);

            //旋转和定向。
            float velocityAngle = Projectile.velocity.ToRotation();
            Projectile.rotation = velocityAngle + (Projectile.spriteDirection == -1).ToInt() * MathHelper.Pi;
            Projectile.direction = (Math.Cos(velocityAngle) > 0).ToDirectionInt();

            //靠近玩家手臂末端的位置。
            Projectile.position = playerRotatedPoint - Projectile.Size * 0.5f + velocityAngle.ToRotationVector2() * 80f;

            //Sprite 和玩家方向。
            Projectile.spriteDirection = Projectile.direction;
            player.ChangeDir(Projectile.direction);

            //基于玩家项目的字段作。
            player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<IDA.Buffs.TerminalHelix>(), 600);
            NPC npc = Main.npc[Projectile.owner];
            Player player = Main.player[Projectile.owner];
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
            Projectile.damage = (int)(target.lifeMax * 0.02f);
        }

        public override Color? GetAlpha(Color lightColor) => new Color(215, 0, 0, 0);
    }
}