namespace BulletExpress.IDA.Buffs
{
    internal class HealOrFatal : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += 0.12f;
            player.lifeRegen += 25;
            if (Main.rand.NextBool(3))
            {
                Dust d = Dust.NewDustDirect(player.position, player.width, player.height, ModContent.DustType<IDA.Powders.Green>());
                d.velocity.X *= 0.1f;
                d.velocity.Y *= 1f;
            }
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ZifNpc>().HealOrFatal = true;
        }
    }
}