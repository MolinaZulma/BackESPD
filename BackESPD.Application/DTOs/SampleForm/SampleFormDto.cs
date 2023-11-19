namespace BackESPD.Application.DTOs.SampleForm
{
    public class SampleFormDto
    {
        public int Id { get; set; }
        public int SampleNumber { get; set; }
        public double MediumFlow { get; set; }
        public double TemperatureC { get; set; }
        public double Ph { get; set; }
        public double CreamWeightKilos { get; set; }
        public double SiftingWeightKilos { get; set; }
        public string IdUNationalIdentificationNumber { get; set; }
        public int IdPlant { get; set; }
    }
}
