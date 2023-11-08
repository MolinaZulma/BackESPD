using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class Plant : AuditableBaseEntity
    {
        public string TypePlant {  get; set; }
        public string Direction {  get; set; }
        public string Description { get; set; }
    }
}
