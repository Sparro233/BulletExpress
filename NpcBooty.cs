namespace BulletExpress
{
    public class NpcBooty : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            //更粘史莱姆
            if (npc.type == NPCID.Slimer)
            {
                //恶魔翅膀
                npcLoot.Add(ItemDropRule.Common(ItemID.DemonWings, 20, 1, 1));
            }
            // 飞翔史莱姆
            if (npc.type == NPCID.QueenSlimeMinionPurple)
            {
                //天使之翼
                npcLoot.Add(ItemDropRule.Common(ItemID.AngelWings, 20, 1, 1));
            }
            /*————封条————*/
            //乌鸦
            if (npc.type == NPCID.Raven)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.IDB.Materials.EncapsulatedGilicon>(), 10, 4, 8));
            }
            //幻灵
            if (npc.type == NPCID.Wraith)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.IDB.Materials.EncapsulatedGilicon>(), 10, 1, 2));
            }
            //死神
            if (npc.type == NPCID.Reaper)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.IDB.Materials.EncapsulatedGilicon>(), 5, 1, 2));
            }
            //远古末日
            if (npc.type == NPCID.AncientDoom)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.IDB.Materials.EncapsulatedGilicon>(), 20, 16, 32));
            }
            /*————封条————*/
            //精灵直升机
            if (npc.type == NPCID.ElfCopter)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.Weapons.Ranged.WasteSoilRifle>(), 10, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.Weapons.Ranged.EmuCatsSubmachineGun>(), 20, 1));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.Ammo.Flare.ThunderZapperBullet>(), 1, 1, 500));
            }
            /*————封条————*/
            //巨鹿
            if (npc.type == 668)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.Ammo.Bullet.HoundiusShootiusFireball>(), 1, 1, 500));
            }
            //骷颅王
            if (npc.type == 35)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.Weapons.Ranged.Launcher.SeaBlueLauncher>()));
            }
            //机械炮
            if (npc.type == NPCID.PrimeCannon)
            {
                npcLoot.Add(ItemDropRule.Common(758, 1));
            }
            //猪龙鱼公爵
            if (npc.type == 370)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BulletExpress.Weapons.Melee.Dance.DeepSeaDagger>(), 4, 1));
            }
        }
    }
}