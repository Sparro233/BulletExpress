namespace BulletExpress
{
    public class ZifNpc : GlobalNPC
    {
        public bool HealOrFatal;
        public bool GilicifiedI;
        public bool GilicifiedII;
        public bool Tetanus;
        public bool LeadPoisoning;
        public bool KillTheSoCalledGods;
        public bool AutumnLeave;
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        public override void ResetEffects(NPC npc)
        {
            HealOrFatal = false;
            GilicifiedI = false;
            GilicifiedII = false;
            Tetanus = false;
            LeadPoisoning = false;
            KillTheSoCalledGods = false;
            AutumnLeave = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (HealOrFatal)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 60;
                if (damage < 15)
                {
                    damage = 15;
                }
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, 46);
                    d.velocity *= 0.7f;
                }
            }
            if (GilicifiedI)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 50;
                if (damage < 5)
                {
                    damage = 5;
                }
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, 46);
                    d.velocity *= 0.7f;
                }
            }
            if (GilicifiedII)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 100;
                if (damage < 10)
                {
                    damage = 10;
                }
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, 46);
                    d.velocity *= 0.7f;
                }
            }
            if (Tetanus)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 20;
                if (damage < 5)
                {
                    damage = 5;
                }
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, 46);
                    d.velocity *= 0.7f;
                }
            }
            if (LeadPoisoning)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 10;
                if (damage < 5)
                {
                    damage = 5;
                }
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, 46);
                    d.velocity *= 0.7f;
                }
            }
            if (KillTheSoCalledGods)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen = -1332;
                if (damage < 444)
                {
                    damage = 444;
                }
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, ModContent.DustType<IDA.Powders.FlawlessI>());
                    d.velocity *= 0.7f;
                }
            }
            if (AutumnLeave)
            {
                npc.defense = 0;
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(npc.position, npc.width, npc.height, ModContent.DustType<IDA.Powders.MapleLeave>());
                    d.velocity.X *= 0.1f;
                    d.velocity.Y *= 1f;
                }
            }
        }
    }

    /*public class ExampleWhipDebuffNPC : GlobalNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
                return;

            var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
            if (npc.HasBuff<IDA.Buffs.LightMark>())
            {
                modifiers.FlatBonusDamage += IDA.Buffs.LightMark.TagDamage * projTagMultiplier;
                modifiers.ScalingBonusDamage += IDA.Buffs.LightMark.TagDamageMultiplier * projTagMultiplier;
                npc.RequestBuffRemoval(ModContent.BuffType<IDA.Buffs.LightMark>());
            }
        }
    }*/
}