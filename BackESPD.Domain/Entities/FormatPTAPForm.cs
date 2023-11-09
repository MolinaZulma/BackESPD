using BackESPD.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackESPD.Domain.Entities
{
    public class FormatPTAPForm
    {
        public int Id {  get; set; }
        public DateTime Date {  get; set; }
        public string TypeWater {  get; set; }
        public double Temperature {  get; set; }
        public double AlkalinityPh {  get; set; }
        public double AlkalineChlorine {  get; set; }
        public double AlkalineInitialReading {  get; set; }
        public double AlkalineFinalReading {  get; set; }
        public double AlkalineTotal {  get; set; }
        public double Alkaline {  get; set; }
        public double ChlorineGas {  get; set; }
        public double ParticlesPerMillion { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("Plant")]
        public int IdPlant { get; set; }
        public virtual Plant IdPlantNavigation { get; set; }
    }
}
