using BackESPD.Domain.BaseEntity;

namespace BackESPD.Domain.Entities
{
    public class DamageReport : AuditableBaseEntity
    {
        public string AddressDamage {  get; set; }
        public string DescriptionDamage {  get; set; }
        public string Image {  get; set; }
        public string TrueInformation {  get; set; }
        public string TypeDamage { get; set; }
        public int IdUser {  get; set; }
    }

}
