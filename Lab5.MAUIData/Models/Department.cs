using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.MAUIData.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Nosaukums { get; set; }
        public int DarbiniekuSK { get; set; }
        public string Apraksts { get; set; }
    }
}
