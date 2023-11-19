namespace BackESPD.Application.DTOs.ActivityLogsForm
{
    public class ActivityLogsFormDto
    {
        public int Id { get; set; }
        public string TypeActivity { get; set; }
        public string Observations { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string UserFullName { get; set; }
        public int IdPlant { get; set; }
        public string NamePlant { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
