using System.Runtime.ConstrainedExecution;

namespace BackESPD.Domain.Entities
{
    public class WaterControlForm
    {
        public DateTime Date { get; set; }
        public double TotalHours { get; set; }
        public double AmountWaterCaptured { get; set; }
        public double AmountWaterSupplied { get; set; }
        public double AluminumSulfate { get; set; }
        public double SodiumHypochlorite { get; set; }
        public double ChlorineGas { get; set; }
        public double ParticlesPerMillion { get; set; }
        public int IdUser { get; set; }
        public int IdPlant { get; set; }
        public virtual Plant IdPlantNavigation {  get; set; }
    }
}
