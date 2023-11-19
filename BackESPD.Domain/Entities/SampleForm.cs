using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class SampleForm : AuditableBaseEntity
    {
        public int SampleNumber {  get; set; }     
        public double MediumFlow {  get; set; }
        public double TemperatureC {  get; set; }
        public double Ph { get; set;}
        public double CreamWeightKilos {  get; set; }   
        public double SiftingWeightKilos {  get; set; }
        public string IdUNationalIdentificationNumber {  get; set; }
        public User IdUserNavigation { get; set; }
        public int IdPlant { get; set; }
        public virtual Plant IdPlantNavigation { get; set; }
    }
}
