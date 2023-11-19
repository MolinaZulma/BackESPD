using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class JarFormatForm : AuditableBaseEntity
    {        
        public int JarConcentration {  get; set; }
        public string JarOptime {  get; set; }
        public int PhJar {  get; set; }
        public string NationalIdentificationNumber {  get; set; }
        public User IdUserNavigation { get; set; }
        public int IdPlant { get; set; }
        public  Plant IdPlantNavigation { get; set; }
    }
}
