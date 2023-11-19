namespace BackESPD.Domain.BaseEntity
{
    public class AuditableBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
