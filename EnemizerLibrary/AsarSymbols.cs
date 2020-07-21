using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Hosting;

namespace EnemizerLibrary
{
    public class AsarSymbols
    {
        public static AsarSymbols Instance => Nested.instance;
        public Dictionary<string, int> Symbols { get; private set; }
        private AsarSymbols(string filename)
        {
            filename = Path.Combine(EnemizerBasePath.Instance.BasePath, filename);

            Symbols = new Dictionary<string, int>();

            var lines = File.ReadAllLines(filename);
            foreach(var l in lines)
            {
                var s = l.Split(new[] { " " }, StringSplitOptions.None);
                if(s.Length != 2)
                {
                    continue;
                }
                var symbol = s[1];
                var snesAddress = int.Parse(s[0].Replace(":",""), System.Globalization.NumberStyles.HexNumber);
                var pcAddress = Utilities.SnesToPCAddress(snesAddress);
                Symbols[symbol] = pcAddress;
            }
        }

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly AsarSymbols instance = new AsarSymbols("exported_symbols.txt");
        }
    }
}
