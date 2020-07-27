namespace EnemizerLibrary
{
    public class OverworldAreaNode : Node
    {
        public int AreaId { get; set; }
        public int PostAgaAreaId { get; set; }
        public OverworldAreaNode(string logicalAreaId, int areaId, string areaName, int postAgaAreaId)
        {
            this.LogicalId = logicalAreaId;
            this.Name = areaName;
            this.AreaId = areaId;
            this.PostAgaAreaId = postAgaAreaId;
        }
    }
}
