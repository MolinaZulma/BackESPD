using Microsoft.AspNetCore.Identity;

namespace BackESPD.Domain.Entities
{
    public class User : IdentityUser
    {
        public string NationalIdentificationNumber {  get; set; }
        public string FullName {  get; set; }

        public virtual ICollection<FormatPTAPForm> FormatPTAPForms { get; } = new List<FormatPTAPForm>();
        public virtual ICollection<ActivityLogsForm> ActivityLogsForm { get; } = new List<ActivityLogsForm>();
        public virtual ICollection<JarFormatForm> JarFormatForm { get; } = new List<JarFormatForm>();
        public virtual ICollection<SampleForm> SampleForm { get; } = new List<SampleForm>();
        public virtual ICollection<WaterControlForm> WaterControlForm { get; } = new List<WaterControlForm>();
        public virtual ICollection<DamageReport> DamageReport { get; } = new List<DamageReport>();

    }
}
