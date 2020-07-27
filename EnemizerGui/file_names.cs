using System.Globalization;

namespace Enemizer
{
    public class files_names
    {
        public string name = "";
        public string file = "";
        public files_names(string name, string file)
        {
            this.name = name;
            this.file = file;
        }
        public override string ToString()
        {
            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            return ti.ToTitleCase(name);
        }

    }
}
