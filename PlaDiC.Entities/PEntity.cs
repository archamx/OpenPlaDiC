using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaDiC.Entities
{
    public class PEntity
    {
        [Column(TypeName = "varchar(50)")]
        public string Id { get; set; }
        public int RecId { get; set; }
        public string? Folio { get; set; }
        public bool IsDisabled { get; set; } = false;
        public bool IsLocal { get; set; } = false;
        public System.DateTime InsertDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? InsertRef { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? UpdateRef { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Owner { get; set; }
    }
}
