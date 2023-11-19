using BackESPD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackESPD.Application.DTOs.JarFormatForm
{
    public class JarFormatFormDto
    {
        public int Id { get; set; }
        public int JarConcentration { get; set; }
        public string JarOptime { get; set; }
        public int PhJar { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public int IdPlant { get; set; }
    }
}
