using BackESPD.Domain.BaseEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackESPD.Domain.Entities
{
    public class Plant : AuditableBaseEntity
    {
        public string TypePlant {  get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
        [ForeignKey("Id")]
        public FormatPTAPForm formatPTAPForm { get; set; }
    }
}
