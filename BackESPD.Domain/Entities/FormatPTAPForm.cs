using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class FormatPTAPForm : AuditableBaseEntity
    {        
        public string TypeWater {  get; set; }
        public double Temperature {  get; set; }
        public double AlkalinityPh {  get; set; }
        public double AlkalineChlorine {  get; set; }
        public double AlkalineInitialReading {  get; set; }
        public double AlkalineFinalReading {  get; set; }
        public double AlkalineTotal {  get; set; }
        public double Alkaline {  get; set; }
        public double ChlorineGas {  get; set; }
        public double ParticlesPerMillion { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public User IdUserNavigation { get; set; }
        public int IdPlant { get; set; }
        public virtual Plant IdPlantNavigation { get; set; }
    }
}
