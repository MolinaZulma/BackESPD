using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class WaterControlForm : AuditableBaseEntity
    {
        public double TotalHours { get; set; }
        public double AmountWaterCaptured { get; set; }
        public double AmountWaterSupplied { get; set; }
        public double AluminumSulfate { get; set; }
        public double SodiumHypochlorite { get; set; }
        public double ChlorineGas { get; set; }
        public double ParticlesPerMillion { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public User IdUserNavigation { get; set; }
        public int IdPlant { get; set; }
        public virtual Plant IdPlantNavigation { get; set; }
    }
}
