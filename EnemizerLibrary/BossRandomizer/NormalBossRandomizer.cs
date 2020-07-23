using System;
using System.Text;

namespace EnemizerLibrary
{
    public class NormalBossRandomizer : BossRandomizer
    {
        public NormalBossRandomizer(Random rand, OptionFlags optionFlags, StringBuilder spoilerFile, Graph graph)
            :base(rand, optionFlags, spoilerFile, graph)
        {
            this.bossPool = new NormalBossPool(rand);
        }
    }
}
