namespace BulletExpress
{
    public class ZifPlayer : ModPlayer
    {
        public bool GilicifiedI;
        public bool GilicifiedII;
        public bool Tetanus;
        public bool LeadPoisoning;
        public bool AutumnLeave;
        public bool AnkhCharmBless;
        public bool GardeningHunt;
        public bool moonbrew;
        public int moontimer = 0;

        public Vector2 recorded_position;
        public int recorded_life;
        public int recorded_mana;
        public int[] recoreded_buff = new int[Player.MaxBuffs];
        public int[] recoreded_bufftime = new int[Player.MaxBuffs];

        public override void ResetEffects()
        {
            LimitSet();
            CommonBuffUpdate();
        }
        public override void UpdateDead()
        {
            CommonBuffUpdate();
        }
        private void LimitSet()
        {
            if (!moonbrew || moontimer < 0)
                moontimer = 0;
            if (moontimer > 0)
                moontimer--;
        }
        private void CommonBuffUpdate()
        {
            GilicifiedI = false;
            GilicifiedII = false;
            Tetanus = false;
            LeadPoisoning = false;
            AutumnLeave = false;
            AnkhCharmBless = false;
            GardeningHunt = false;
        }
        public override void UpdateLifeRegen()
        {
            if (GilicifiedI)
            {
                Player.GetDamage(DamageClass.Generic) += 0.5f;
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 4;
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(Player.position, Player.width, Player.height, 46);
                    d.velocity *= 0.7f;
                }
            }
            if (GilicifiedII)
            {
                Player.GetDamage(DamageClass.Generic) += 1f;
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 8;
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(Player.position, Player.width, Player.height, 46);
                    d.velocity *= 0.7f;
                }
            }
            if (Tetanus)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegen -= 20;
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(Player.position, Player.width, Player.height, 46);
                    d.velocity *= 0.7f;
                }
            }
            if (LeadPoisoning)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegen -= 20;
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(Player.position, Player.width, Player.height, 46);
                    d.velocity *= 0.7f;
                }
            }
            if (AutumnLeave)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                if (Main.rand.NextBool(3))
                {
                    Dust d = Dust.NewDustDirect(Player.position, Player.width, Player.height, ModContent.DustType<IDA.Powders.MapleLeave>());
                    d.velocity.Y *= 1f;
                    d.velocity.X *= 0.1f;
                }
            }
            if (AnkhCharmBless)
            {
                //√‚“ﬂ÷–∂ædebuff
                Player.buffImmune[BuffID.Poisoned] = true;
                //√‚“ﬂ∫⁄∞µdebuff
                Player.buffImmune[BuffID.Darkness] = true;
                //√‚“ﬂ◊Á÷‰debuff
                Player.buffImmune[BuffID.Cursed] = true;
                //√‚“ﬂ¡˜—™debuff
                Player.buffImmune[BuffID.Bleeding] = true;
                //√‚“ﬂ¿ßªÛdebuff
                Player.buffImmune[BuffID.Confused] = true;
                //√‚“ﬂª∫¬˝debuff
                Player.buffImmune[BuffID.Slow] = true;
                //√‚“ﬂ»Ì»ıdebuff
                Player.buffImmune[BuffID.Weak] = true;
                //√‚“ﬂ≥¡ƒ¨debuff
                Player.buffImmune[BuffID.Silenced] = true;
                //√‚“ﬂø¯º◊∆∆Àdebuff
                Player.buffImmune[BuffID.BrokenArmor] = true;
                //√‚“ﬂ ØªØdebuff
                Player.buffImmune[BuffID.Stoned] = true;
            }
            if (GardeningHunt)
            {
                Player.endurance += 0.2f;
            }
        }
        
        public override void UpdateBadLifeRegen()
        {
            if (Tetanus)
            {
                if (Player.lifeRegen < 0)
                {
                    Player.lifeRegen = (int)(Player.lifeRegen * 0.5f);
                }
            }
        }
    }
}