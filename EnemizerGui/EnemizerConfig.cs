using EnemizerLibrary;
using System;

namespace Enemizer
{
    public class EnemizerConfig
    {
        public bool CheckForUpdates { get; set; } = true;
        public string DefaultFolder { get; set; } = String.Empty;
        public bool BulkSeeds { get; set; } = false;
        public int NumberOfBulkSeeds { get; set; } = 1;
        public OptionFlags OptionFlags { get; set; } = new OptionFlags();
    }
}
