using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnemizerCLI
{
    public class CommandLineOptions
    {
        [Option("rom", Required = true, HelpText = "path to the base rom file")]
        public string BaseRomFilename { get; set; }

        [Option("seed", Required = false, Default = "", HelpText = "seed number")]
        public string SeedNumber { get; set; }

        [Option("base", Required = false, HelpText = "path to the base2patched.json (not used in binary mode)")]
        public string BasePatchJsonFilename { get; set; }

        [Option("randomizer", Required = false, HelpText = "path to the randomizerPatch.json (not used in binary mode)")]
        public string RandomizerPatchJsonFilename { get; set; }

        [Option("enemizer", Required = true, HelpText = "path to the enemizerOptions.json")]
        public string EnemizerOptionsJsonFilename { get; set; }

        [Option("output", Required = true, HelpText = "path to the intended output file")]
        public string OutputFilePath { get; set; }

        [Option("binary", Default=false, Required = false, HelpText = "operate in binary mode (takes already randomized SFC and applies enemizer directly to ROM)")]
        public bool BinaryMode { get; set; }
    }
}
