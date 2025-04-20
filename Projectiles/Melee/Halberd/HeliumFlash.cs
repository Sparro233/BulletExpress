namespace BulletExpress.Projectiles.Melee.Halberd
{
    public class HeliumFlash : ModProjectile, ILocalizedModType
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 240;
            Projectile.height = 240;
            Projectile.light = 2f;

            Projectile.timeLeft = 10;
            Projectile.penetrate = -1;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.SetDefaults();
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            modifiers.Knockback *= Main.player[Projectile.owner].velocity.Length() / 7f;
            modifiers.SourceDamage *= 0.1f + Main.player[Projectile.owner].velocity.Length() / 7f * 0.9f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 600);
            Projectile.damage = (int)(Projectile.damage * 0.8f);
        }
    }
}