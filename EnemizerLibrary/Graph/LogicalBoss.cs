using System.Linq;

namespace EnemizerLibrary
{
    public class LogicalBoss : Node
    {
        public SpecialItem Boss { get; set; }

        public LogicalBoss(string logicalId, string name, string requirements)
        {
            this.LogicalId = logicalId;
            this.Name = name;
            this.Boss = (SpecialItem)Data.GameItems.Items.Values.Where(x => x.LogicalId == logicalId).FirstOrDefault();
        }
    }
}
