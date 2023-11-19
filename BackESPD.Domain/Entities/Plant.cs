using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class Plant : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string TypePlant {  get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
        public FormatPTAPForm FormatPTAPForm { get; set; }
        public ActivityLogsForm ActivityLogsForm { get; set; }
        public JarFormatForm JarFormatForm { get; set; }
        public SampleForm SampleForm { get; set; }
        public WaterControlForm WaterControlForm { get; set; }
    }
}
