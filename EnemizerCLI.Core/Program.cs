using CommandLine;
using CommandLine.Text;
using EnemizerLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EnemizerCLI.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new StringWriter();
            var parser = new Parser(conf => conf.HelpWriter = writer);
            var result = parser.ParseArguments<CommandLineOptions>(args);

            result.WithNotParsed(error =>
            {
                Console.WriteLine(writer.ToString());
                Environment.Exit(1);
            }).WithParsed(options =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                if (options.BinaryMode)
                {
                    MakeEnemizerRom(options);
                }
                else
                {
                    MakeEnemizerJsonPatch(options);
                }

                stopwatch.Stop();
                Console.WriteLine($"Seed generated in: {stopwatch.Elapsed}");
            });
        }

        private static void MakeEnemizerRom(CommandLineOptions options)
        {
            var optionFlags = JsonConvert.DeserializeObject<OptionFlags>(File.ReadAllText(options.EnemizerOptionsJsonFilename));

            byte[] rawData = File.ReadAllBytes(options.BaseRomFilename);
            Array.Resize(ref rawData, 2 * 1024 * 1024);

            RomData romData = new RomData(rawData);
            ThrowIfAlreadyEnemized(romData);

            int seed = GetSeed(options);
            byte[] enemPatch = GenerateRom(seed, rawData, optionFlags);

            File.WriteAllBytes(options.OutputFilePath, enemPatch);
            Console.WriteLine($"Generated SFC file {options.OutputFilePath}");
        }

        static void MakeEnemizerJsonPatch(CommandLineOptions options)
        {
            var basePatchJson = File.ReadAllText(options.BasePatchJsonFilename);
            var randoPatchJson = File.ReadAllText(options.RandomizerPatchJsonFilename);
            var optionFlags = JsonConvert.DeserializeObject<OptionFlags>(File.ReadAllText(options.EnemizerOptionsJsonFilename));

            byte[] rawData = File.ReadAllBytes(options.BaseRomFilename);
            Array.Resize(ref rawData, 2 * 1024 * 1024);

            RomData romData = new RomData(rawData);
            ThrowIfAlreadyEnemized(romData);

            int seed = GetSeed(options);
            var enemPatch = GenerateSeed(seed, rawData, optionFlags);
            var patchJson = JsonConvert.SerializeObject(enemPatch);

            File.WriteAllText(options.OutputFilePath, patchJson);
            Console.WriteLine($"Generated JSON file {options.OutputFilePath}");
        }

        static List<PatchObject> GenerateSeed(int seed, byte[] rom_data, OptionFlags optionFlags)
        {
            RomData randomizedRom = RandomizeRom(seed, rom_data, optionFlags);

            return randomizedRom.GeneratePatch();
        }

        static byte[] GenerateRom(int seed, byte[] rom_data, OptionFlags optionFlags)
        {
            RomData randomizedRom = RandomizeRom(seed, rom_data, optionFlags);

            var romfs = new MemoryStream();
            randomizedRom.WriteRom(romfs);
            romfs.Flush();

            var romBytes = romfs.ToArray();
            return romBytes;
        }

        private static RomData RandomizeRom(int seed, byte[] rom_data, OptionFlags optionFlags)
        {
            RomData romData = new RomData(rom_data);
            Randomization randomize = new Randomization();
            RomData randomizedRom = randomize.MakeRandomization("", seed, optionFlags, romData, "");
            return randomizedRom;
        }

        private static int GetSeed(CommandLineOptions options)
        {
            Random rand = new Random();
            if (string.IsNullOrEmpty(options.SeedNumber))
            {
                return rand.Next(0, 999999999);
            }
            else
            {
                // TODO: add validation to the textbox so it can't be anything but a number
                if (!int.TryParse(options.SeedNumber, out var seed))
                {
                    throw new Exception("Invalid Seed Number entered. Please enter an integer value.");
                }
                if (seed < 0)
                {
                    throw new Exception("Please enter a positive Seed Number.");
                }
                return seed;
            }
        }

        private static void ThrowIfAlreadyEnemized(RomData romData)
        {
            if (romData.IsEnemizerRom)
            {
                throw new Exception("It appears that the provided base ROM is already enemized. Please ensure you are using an original game ROM.");
            }
        }
    }
}
