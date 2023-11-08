using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class JarFormatForm : AuditableBaseEntity
    {
        public DateTime Date { get; set; }
        public int JarConcentration {  get; set; }
        public string JarOptime {  get; set; }
        public int PhJar {  get; set; }
        public int IdUser {  get; set; }
    }
}
