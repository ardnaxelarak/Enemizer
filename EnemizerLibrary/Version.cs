using System.Net;

namespace EnemizerLibrary
{
    public class Version
    {
        public const int MajorVersion = 6;
        public const int MinorVersion = 0;
        public const int BuildNumber = 32; // max 99 to show up in rom
        public static string CurrentVersion = $"{MajorVersion}.{MinorVersion}.{BuildNumber:D2}";

        public static bool CheckUpdate()
        {
            var checkVersion = "";
            using (var wc = new WebClient())
            {
                checkVersion = wc.DownloadString("https://zarby89.github.io/Enemizer/version.txt");
            }
            var numbers = checkVersion.Replace("\r", "").Replace("\n", "").Trim().Split('.');
            if (int.Parse(numbers[0]) >= MajorVersion)
            {
                if (int.Parse(numbers[1]) >= MinorVersion)
                {
                    if (int.Parse(numbers[2]) > BuildNumber)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
