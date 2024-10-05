using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaDiC.Entities
{
    public class PickListValue: PEntity
    {
        [Column(TypeName = "varchar(50)")]
        public string PickListId { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Label { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int Value { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Code { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Color { get; set; }
        public bool IsDefault { get; set; }
        public int Secuence { get; set; }
    }
}
