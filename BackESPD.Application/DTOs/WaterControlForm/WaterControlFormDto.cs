namespace BackESPD.Application.DTOs.WaterControlForm
{
    public class WaterControlFormDto
    {
        public int Id { get; set; }
        public double TotalHours { get; set; }
        public double AmountWaterCaptured { get; set; }
        public double AmountWaterSupplied { get; set; }
        public double AluminumSulfate { get; set; }
        public double SodiumHypochlorite { get; set; }
        public double ChlorineGas { get; set; }
        public double ParticlesPerMillion { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string UserFullName { get; set; }
        public int IdPlant { get; set; }
        public string NamePlant { get; set; }

    }
}
