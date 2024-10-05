using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaDiC.Entities
{
    public class Object: PEntity
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Prefix { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Label { get; set; }
        public string Description { get; set; }
        public string? Icono { get; set; }
        public bool UseName { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? NameLabel { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? NameHint { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool IsVisible { get; set; } = false;
        public bool IsDetail { get; set; } = false;
        public bool IsRelated { get; set; } = false;
        public bool IsAccessControlled { get; set; } = false;
        public bool CustomSentence { get; set; } = false;
        public string? ListSentence { get; set; }
        public string? RelatedSentence { get; set; }
        public string? FieldsSentence { get; set; }
        public string? FilterSentence { get; set; }
        public int MaxListRecords { get; set; }
        public int MaxRelatedRecords { get; set; }
        public string? AITriggerCode { get; set; }
        public string? BITriggerCode { get; set; }
        public string? AUTriggerCode { get; set; }
        public string? BUTriggerCode { get; set; }
        public string? ADTriggerCode { get; set; }
        public string? BDTriggerCode { get; set; }

        [InverseProperty("Object")]
        public virtual ICollection<ObjectProperty> ObjectProperties { get; set; }

        [InverseProperty("RefObject")]
        public virtual ICollection<ObjectProperty> RefObjectProperties { get; set; }

    }
}
