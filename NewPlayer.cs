namespace BulletExpress
{
    public class NewPlayer : ModPlayer
    {
        //这个函数可以给玩家添加初始物品
        //这里给的参数是说玩家是否是中核难度
        //因为中核玩家死亡时物品栏会被清空然后重置为初始开局物品
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            //返回一个集合，不管是list还是数组都可以
            return new[]
            {
                //铜弹药发射器，氪晶，
                new Item(ModContent.ItemType<BulletExpress.Weapons.Ranged.Launcher.CopperAmmoLauncher>()),
                new Item(ModContent.ItemType<BulletExpress.IDB.Accessories.KryptonCrystal>()),
                //辣椒
                new Item(5277)
            };
        }
        //这个函数用于修改玩家的初始物品，可以把原版自带的东西删掉
        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {
            //Terraria为原版的键，用它就能拿到原版提供的初始物品
            //把原版提供的铜镐删掉
            //ItemsByMod["Terraria"].RemoveAll(item => item.type == ItemID.CopperPickaxe);
            //把刚刚我们的Mod提供的木头也删掉（乐
            //ItemsByMod[Mod.BulletExpress].RemoveAll(item => item.type == ItemID.Wood);
            //这里的键名即是Mod的内部名
        }
    }
}