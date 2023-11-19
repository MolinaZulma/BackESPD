using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class Plant : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string TypePlant {  get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FormatPTAPForm> FormatPTAPForm { get; } = new List<FormatPTAPForm>();
        public virtual ICollection<ActivityLogsForm> ActivityLogsForm { get; } = new List<ActivityLogsForm>();
        public virtual ICollection<JarFormatForm> JarFormatForm { get; } = new List<JarFormatForm>();
        public virtual ICollection<SampleForm> SampleForm { get; } = new List<SampleForm>();
        public virtual ICollection<WaterControlForm> WaterControlForm { get; } = new List<WaterControlForm>();
            
    }
}
