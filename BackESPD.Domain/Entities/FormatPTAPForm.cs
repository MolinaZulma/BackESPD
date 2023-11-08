using BackESPD.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackESPD.Domain.Entities
{
    public class FormatPTAPForm : AuditableBaseEntity
    {
        public DateTime Date {  get; set; }
        public string WaterClass {  get; set; }
        public int Temperature {  get; set; }
        public string AlkalinityPh {  get; set; }
        public string AlkalineChlorine {  get; set; }
        public string AlkalineInitialReading {  get; set; }
        public string AlkalineFinalReading {  get; set; }
        public string AlkalineTotal {  get; set; }
        public string Alkaline {  get; set; }
        public double ChlorineGas {  get; set; }
        public double ParticlesPerMillion { get; set; }
        public int IdUser { get; set; }
        public int IdPlant { get; set; }
        public virtual Plant IdPlantNavigation { get; set; }
    }
}
