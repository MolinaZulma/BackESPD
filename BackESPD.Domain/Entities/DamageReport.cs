namespace BackESPD.Domain.Entities
{
    public class DamageReport
    {
        public int Id { get; set; }
        public string AddressDamage {  get; set; }
        public string DescriptionDamage {  get; set; }
        public string Image {  get; set; }
        public string TrueInformation {  get; set; }
        public string TypeDamage { get; set; }
        public string IdUser { get; set; }
        public User IdUserNavigation { get; set; }
    }

}
