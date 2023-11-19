namespace BackESPD.Application.DTOs.ActivityLogsForm
{
    public class ActivityLogsFormDto
    {
        public int Id { get; set; }
        public string TypeActivity { get; set; }
        public string Observations { get; set; }
        public string IdUser { get; set; }
        public int IdPlant { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
