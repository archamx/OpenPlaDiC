using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaDiC.Entities
{
    public class PickList: PEntity
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Label { get; set; }
        public string? Description { get; set; }
        public bool IsGlobal { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? ObjectPropertyId { get; set; }

        public virtual ICollection<PickListValue> PickListValues { get; set; }
    }
}
