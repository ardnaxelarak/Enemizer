using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace BinComp
{
	public class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("BinComp ---- ");
			if (args.Length != 3)
			{
				PrintUsage();
				return;
			}

			var asmFilename = args[0];
			var basePatchJson = args[1];
			var symbolsFilename = args[2];
			Console.WriteLine($"input asm: {asmFilename}");
			Console.WriteLine($"output file: {basePatchJson}");
			Console.WriteLine($"Exported Symbols: {symbolsFilename}");

			Console.WriteLine($"Cleaning up for a fresh build attempt.");

			// ReSharper disable InconsistentNaming
			// ReSharper disable JoinDeclarationAndInitializer
			byte[] patch_0x00;
			byte[] patch_0xFF;

			var tempFile_0x00 = Guid.NewGuid() + ".tmp";
			var tempFile_0xFF = Guid.NewGuid() + ".tmp";
			// ReSharper restore InconsistentNaming
			// ReSharper restore JoinDeclarationAndInitializer

			Console.WriteLine($"temp file (zeros): {tempFile_0x00}");
			Console.WriteLine($"temp file (0xFF): {tempFile_0xFF}");

			RunAsar(asmFilename, tempFile_0x00, symbolsFilename);

			Console.WriteLine("Reading all 0x00 file.");
			FileStream fileStream = new FileStream(tempFile_0x00, FileMode.Open, FileAccess.Read);
			patch_0x00 = new byte[fileStream.Length];
			fileStream.Read(patch_0x00, 0, (int)fileStream.Length);
			fileStream.Close();
			Console.WriteLine("Read all 0x00 file.");


			Console.WriteLine("Generating all 0xFF file.");
			fileStream = new FileStream(tempFile_0xFF, FileMode.CreateNew, FileAccess.Write);
			patch_0xFF = Enumerable.Repeat(byte.MaxValue, patch_0x00.Length).ToArray();
			fileStream.Write(patch_0xFF, 0, patch_0xFF.Length);
			fileStream.Flush();
			fileStream.Close();
			Console.WriteLine("Generated all 0xFF file.");

			RunAsar(asmFilename, tempFile_0xFF, symbolsFilename);

			Console.WriteLine("Reading all 0xFF patched file.");
			fileStream = new FileStream(tempFile_0xFF, FileMode.Open, FileAccess.Read);
			patch_0xFF = new byte[fileStream.Length];
			fileStream.Read(patch_0xFF, 0, (int)fileStream.Length);
			fileStream.Close();
			Console.WriteLine("Read all 0xFF patched file.");


			if (patch_0x00.Length != patch_0xFF.Length)
			{
				Console.WriteLine("File lengths don't match! Aborting.");
				throw new Exception("file lengths don't match!");
			}

			Console.WriteLine("");
			var list = new List<Patch>();
			Patch patch = null;
			var flag = true;
			for (var i = 0; i < patch_0x00.Length; i++)
			{
				if (patch_0x00[i] != patch_0xFF[i])
				{
					flag = patch_0x00[i] == 0x00 && patch_0xFF[i] == 0xFF;
					if (flag) 
						continue;

					Console.WriteLine("Something went wrong. Zero file has non-zero or FF file has non-FF where files do not match!");
					throw new Exception("Something went wrong. Zero file has non-zero or FF file has non-FF where files do not match!");
				}

				if (flag)
				{
					Console.WriteLine($"New patch data found at address {i:X}");
					flag = false;
					patch = new Patch {address = i};
					list.Add(patch);
				}
				patch.patchData.Add(patch_0x00[i]);
			}
			Console.WriteLine("Writing patch data file.");
			File.WriteAllText(basePatchJson, JsonConvert.SerializeObject(list));

			Console.WriteLine("Cleaning up temp files.");
			File.Delete(tempFile_0x00);
			File.Delete(tempFile_0xFF);
			Console.WriteLine("BinComp finished ----");
		}

		private static void PrintUsage()
		{
			Console.WriteLine("bincomp.exe [input.asm] [output.json] [symbols.txt]");
		}

		private static void CmdReadOutput(object sender, DataReceivedEventArgs e, AutoResetEvent outputWaitHandle, StringBuilder output)
		{
			if (e.Data == null)
			{
				outputWaitHandle.Set();
				return;
			}
			output.AppendLine(e.Data);
		}

		private static void RunAsar(string asmFilename, string romFilename, string symbolsFilename)
		{
			Console.WriteLine($"---- Running asar --no-title-check --fix-checksum=off --symbols=wla --symbols-path={symbolsFilename} {asmFilename} {romFilename} ----");
			using (Process process = new Process())
			{
				process.StartInfo.FileName = "asar.exe";
				process.StartInfo.Arguments = $"--no-title-check --fix-checksum=off --symbols=wla --symbols-path={symbolsFilename} {asmFilename} {romFilename}";
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.UseShellExecute = false;
				StringBuilder output = new StringBuilder();
				StringBuilder error = new StringBuilder();
				using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
				{
					using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
					{
						process.OutputDataReceived += (sender, e) => CmdReadOutput(sender, e, outputWaitHandle, output);
						process.ErrorDataReceived += (sender, e) => CmdReadOutput(sender, e, errorWaitHandle, error);

						process.Start();
						process.BeginOutputReadLine();
						process.BeginErrorReadLine();
						process.WaitForExit();
						outputWaitHandle.WaitOne();
						errorWaitHandle.WaitOne();
						Console.WriteLine(output.ToString());
						Console.WriteLine(error.ToString());
						if (process.ExitCode != 0)
						{
							Console.WriteLine("asar threw errors");
							throw new Exception("asar threw errors");
						}
					}
				}
			}
			Console.WriteLine("---- asar finished ----");
		}
	}
}
