using EnemizerLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace BasePatchGenerator
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: BasePatchGenerator.exe [rom file] [patch data] [output file]");
                return;
            }

            Console.WriteLine($"Reading rom file {args[0]}");
            var fs = new FileStream(args[0], FileMode.Open, FileAccess.Read);
            var rom_data = new byte[fs.Length];
            fs.Read(rom_data, 0, (int)fs.Length);
            fs.Close();

            if (rom_data.Length % 1024 == 512)
            {
                Console.WriteLine("Stripping rom header");
                rom_data = rom_data.Skip(512).ToArray();
            }

            using (var md5 = MD5.Create())
            {
                Console.WriteLine("Verifying rom");
                var hash = md5.ComputeHash(rom_data);
                if (!hash.SequenceEqual(new byte[] { 0x03, 0xa6, 0x39, 0x45, 0x39, 0x81, 0x91, 0x33, 0x7e, 0x89, 0x6e, 0x57, 0x71, 0xf7, 0x71, 0x73 }))
                {
                    throw new Exception("Invalid rom file");
                }
            }

            Console.WriteLine("Applying Patch to rom");
            Array.Resize(ref rom_data, 4 * 1024 * 1024);

            var rom = new RomData(rom_data);

            var patch = new Patch(args[1]);
            patch.PatchRom(rom);

            GeneralPatches.MoveRoomHeaders(rom);

            var patches = rom.GeneratePatch();

            patch.AddPatches(patches);

            var patchJson = patch.ExportJson();

            Console.WriteLine($"Writing output file {args[2]}");
            File.WriteAllText(args[2], patchJson);
        }
    }
}
