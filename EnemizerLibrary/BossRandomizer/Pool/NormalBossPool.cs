using System;

namespace EnemizerLibrary
{
    public class NormalBossPool : BossPool
    {
        public NormalBossPool(Random rand)
            :base(rand)
        {

        }

        protected override void FillGTPool()
        {
            pool.Add(Boss.GetRandomBoss(rand, new GT1Dungeon())); // GT1
            pool.Add(Boss.GetRandomBoss(rand, new GT2Dungeon())); // GT2
            pool.Add(Boss.GetRandomBoss(rand, new GT3Dungeon())); // GT3
        }

    }
}
