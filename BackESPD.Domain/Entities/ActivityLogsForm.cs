using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class ActivityLogsForm : AuditableBaseEntity
    {        
        public string TypeActivity {  get; set; }
        public string Observations {  get; set; }
        public string IdUser {  get; set; }
        public User IdUserNavigation { get; set; }
        public int IdPlant { get; set; }
        public virtual Plant IdPlantNavigation { get; set; }
    }
}
