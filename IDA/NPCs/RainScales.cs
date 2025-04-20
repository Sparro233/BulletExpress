namespace BulletExpress.IDA.NPCs
{
    [AutoloadHead]
    public class RainScales : ModNPC
    {
        int npcID = NPCID.Princess;
        public override void SetStaticDefaults()
        {
            //总帧数，根据使用贴图的实际帧数进行填写，这里我们直接调用全部商人的数据
            Main.npcFrameCount[Type] = Main.npcFrameCount[npcID];

            //特殊交互帧（如坐下，攻击）的数量，其作用就是规划这个NPC的最大行走帧数为多少，
            //最大行走帧数即Main.npcFrameCount - NPCID.Sets.ExtraFramesCount
            NPCID.Sets.ExtraFramesCount[Type] = NPCID.Sets.ExtraFramesCount[npcID];

            //攻击帧的数量，取决于你的NPC属于哪种攻击类型，如何填写见上文的分类讲解
            NPCID.Sets.AttackFrameCount[Type] = NPCID.Sets.AttackFrameCount[npcID];

            //NPC的攻击方式，同样取决于你的NPC属于哪种攻击类型，投掷型填0，远程型填1，魔法型填2，近战型填3，
            //如果是宠物没有攻击手段那么这条将不产生影响
            NPCID.Sets.AttackType[Type] = NPCID.Sets.AttackType[npcID];

            //NPC的帽子位置中Y坐标的偏移量，这里特指派对帽，
            //当你觉得帽子戴的太高或太低时使用这个做调整（所以为什么不给个X的）         
            NPCID.Sets.HatOffsetY[Type] = NPCID.Sets.HatOffsetY[npcID];

            //这个名字比较抽象，可以理解为 [记录了NPC的某些帧带来的身体起伏量的数组] 的索引值，
            //而这个数组的名字叫 NPCID.Sets.TownNPCsFramingGroups ，详情请在源码的NPCID.cs与Main.cs内进行搜索。
            //举个例子：你应该注意到了派对帽或是机械师背后的扳手在NPC走动时是会不断起伏的，靠的就是用这个进行调整，
            //所以说在画帧图时最好比着原版NPC的帧图进行绘制，方便各种数据调用
            //补充：这个属性似乎是针对城镇NPC的。
            NPCID.Sets.NPCFramingGroup[Type] = NPCID.Sets.NPCFramingGroup[npcID];

            //魔法型NPC在攻击时产生的魔法光环的颜色，如果NPCID.Sets.AttackType不为2那就不会产生光环
            //如果NPCID.Sets.AttackType为2那么默认为白色
            NPCID.Sets.MagicAuraColor[Type] = Color.White; //Blue

            //NPC的单次攻击持续时间，如果你的NPC需要持续施法进行攻击可以把这里设置的很长，
            //比如树妖的这个值就高达600
            //补充说明一点：如果你的NPC的AttackType为3即近战型，
            //这里最好选择套用，因为近战型NPC的单次攻击时间是固定的
            NPCID.Sets.AttackTime[Type] = NPCID.Sets.AttackTime[npcID];

            //NPC的危险检测范围，以像素为单位，这个似乎是半径
            NPCID.Sets.DangerDetectRange[Type] = 400;

            //NPC在遭遇敌人时发动攻击的概率，如果为0则该NPC不会进行攻击（待验证）
            //遇到危险时，该NPC在可以进攻的情况下每帧有 1 / (NPCID.Sets.AttackAverageChance * 2) 的概率发动攻击
            //注：每帧都判定
            NPCID.Sets.AttackAverageChance[Type] = 10;
        }

        public override void SetDefaults()
        {
            //判断该NPC是否为城镇NPC，决定了这个NPC是否拥有幸福度对话，是否可以对话以及是否会被地图保存
            //当然以上这些属性也可以靠其他的方式开启或关闭，我们日后再说
            NPC.townNPC = true;

            //该NPC为友好NPC，不会被友方弹幕伤害且会被敌对NPC伤害
            NPC.friendly = true;

            //碰撞箱宽，不做过多解释，此处为标准城镇NPC数据
            NPC.width = 18;

            //碰撞箱高，不做过多解释，此处为标准城镇NPC数据
            NPC.height = 40;

            //套用原版城镇NPC的AIStyle，这样我们就不用自己费劲写AI了，
            //同时根据我以往的观测结果发现这个属性也决定了NPC是否会出现在入住列表里，还请大佬求证
            NPC.aiStyle = NPCAIStyleID.Passive;

            //伤害，由于城镇NPC没有体术所以这里特指弹幕伤害（虽然弹幕伤害也是单独设置的所以理论上这个可以不写？）
            NPC.damage = 255;

            //防御力
            NPC.defense = 4;

            //最大生命值，此处为标准城镇NPC数据
            NPC.lifeMax = 100;

            //受击音效
            NPC.HitSound = SoundID.NPCHit1;
            
            //死亡音效
            NPC.DeathSound = SoundID.NPCDeath1;
            
            //抗击退性，数据越小抗性越高
            NPC.knockBackResist = 1f;
            
            //模仿的动画类型，这样就不用自己费劲写动画播放了
            AnimationType = NPCID.Princess; //17
        }

        //设置入住条件
        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            //返回条件为：
            return numTownNPCs >= 7;
        }

        //设置姓名
        public override List<string> SetNPCNameList()
        {
            //所有可能出现的名字
            return new List<string>()
            {
                "Boundless",
                "Mouse",
                "Rain scales",
                "Scales"
            };
        }

        //决定NPC会被哪座雕像传送
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return !toKingStatue;
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();
            chat.Add(Language.GetTextValue("如果所有人都是真心，那我岂不欺骗了所有人……"));
            chat.Add(Language.GetTextValue("生命啊，矛盾的活着。"));
            chat.Add(Language.GetTextValue("你想再知道些什么？"));
            chat.Add(Language.GetTextValue("祈愿会带来同等的绝望。"));
            chat.Add(Language.GetTextValue("在这个世界所有人都可以随心所欲的作死，反正过一会就复活了！"));
            chat.Add(Language.GetTextValue("当你凝视深渊时，深渊也在凝视着你，但我就是深渊。"));
            chat.Add(Language.GetTextValue("RinaEndewote有谈到我有严重的双向情感障碍，但是我不得不假装自己没有任何问题。"));
            chat.Add(Language.GetTextValue("我暂时不会告诉你任何有价值的事情，因为我现在只想在这个世界来抱怨我经历的一切"));
            chat.Add(Language.GetTextValue("有些史莱姆会入侵镇子，为什么不阻止它们，你可以。"));
            chat.Add(Language.GetTextValue("兜帽下的面容是什么，我也不知道。"));
            chat.Add(Language.GetTextValue("和某个人很像？你是说Archon？"));
            string chosenChat = chat;
            return chosenChat;
        }


        //设置对话按钮的文本
        public override void SetChatButtons(ref string button, ref string button2)
        {
            //直接引用原版的“商店”文本
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = "Shop";
            }
        }

        public override void AddShops()
        {
            new NPCShop(Type)
                .Add(ModContent.ItemType<Weapons.Horti.InkGlassSword>(), (Condition.DownedPlantera))
                .Add(ModContent.ItemType<IDB.Accessories.KryptonCrystal>())
                .Add(new Item(225) { shopCustomPrice = 200 })
                .Add(ModContent.ItemType<IDB.Materials.StrayCotton>(), (Condition.Hardmode))
                .Add(ModContent.ItemType<IDB.Materials.WheatEar>(), (Condition.Hardmode))
                .Register();
        }

        //设置NPC的攻击力
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            //伤害，直接调用NPC本体的伤害
            damage = NPC.damage;
            //击退力，中规中矩的数据
            knockback = 9f;
        }

        //设置每次攻击完毕后的冷却时间
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            //基础冷却时间
            cooldown = 5;
            //额外冷却时间
            randExtraCooldown = 1;
        }

        //设置发射的弹幕
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Main.hardMode)
            {
                projType = ModContent.ProjectileType<Projectiles.Horti.InkGlassSword > ();
            }
            else
            {
                projType = ModContent.ProjectileType<Projectiles.Horti.Tear>();
            }
            attackDelay = 10;
        }
        
        //设置发射弹幕的向量
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            //发射速度
            multiplier = 12f;
            //射击时产生的最大额外向量偏差
            randomOffset = 0.2f;
        }
    }
}
