namespace BulletExpress.Projectiles.Ranged
{
    public class TitaniumPetals : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Ranged";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 12;
            Projectile.height = 12;
            DrawOffsetX = -10;
            DrawOriginOffsetY = -10;

            Projectile.timeLeft = 90;
            Projectile.penetrate = 4;
            Projectile.localNPCHitCooldown = 20;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X * 0.1f;
            Projectile.velocity *= 0.99f;
            Projectile.velocity = Projectile.velocity.RotatedBy(-0.1f);
        }

        //</summary>///<param name="lightColor">用来影响光照的颜色。</param>
        //<returns>返回true表示此方法已经处理了绘制，不再重复绘制。</returns>
        public override bool PreDraw(ref Color lightColor)
        {
            //计算绘制原点，以便在旋转和缩放时以中心为基准
            Vector2 drawOrigin = new(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            //遍历所有旧位置以绘制轨迹
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                //计算当前绘制位置，考虑屏幕位置和贴图的偏移
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                //计算当前颜色，逐渐减少透明度以创建轨迹效果
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                //绘制当前弹幕贴图，应用旋转和缩放
                Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            //返回true以指示绘制已经处理
            return true;
        }
        //我想怎么写，就怎么写🧐☝️

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.velocity = (target.Center - Projectile.Center) * 0.5f;
        }

        public override void OnKill(int timeLeft)
        {
            if (Projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 v = new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(2, -2));
                    Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, v, ModContent.ProjectileType<TitaniumPetalsI>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                }
            }
        }
    }
}
