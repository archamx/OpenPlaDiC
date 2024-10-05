using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaDiC.Entities
{
    public enum PropertyType
    {
        Text = 0,
        Integer = 1,
        Numeric = 2,
        Date = 3,
        DateTime = 103,
        Email = 4,
        Phone = 5,
        Geolocation = 6,
        Memo = 7,
        Image = 8,
        Binary = 9,
        RelatedList = 10,
        Checkbox = 11,
        Password = 12,
        Percentage = 13,
        Color = 14,
        File = 15,
        Currency = 16,
        Base64 = 17,
        XML = 18,
        GenericList = 19,
        PickList = 20,
        ValueList = 21,
        URL = 22,
        VideoLink = 23,
        Video = 24,
        Geofence = 25,
        SQLCode = 26,
        RazorCode = 27

    }
    public class ObjectProperty: PEntity
    {
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Label { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Hint { get; set; }
        public PropertyType Type { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? DefaultValue { get; set; }
        public string? RegExp { get; set; }
        public int MaxLng { get; set; }
        public decimal MaxVal { get; set; }
        public decimal MinVal { get; set; }
        public bool IsRequired { get; set; }
        public string? RelatedSentence { get; set; }
        public string? FieldsSentece { get; set; }
        public string? Formula { get; set; }
        public string? Group { get; set; }
        public int Secuence { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        public int Option { get; set; }
        public bool IsVisible { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsVisibleInList { get; set; }
        public bool IsVisibleInRelated { get; set; }
        public bool IsFilter { get; set; }
        public bool IsUnique { get; set; }
        public bool IsIndexed { get; set; }

        [ForeignKey("Object")]
        [Column(TypeName = "varchar(50)")]
        public string ObjectId { get; set; }
        public Object Object { get; set; }

        [ForeignKey("RefObject")]
        [Column(TypeName = "varchar(50)")]
        public string RefObjectId { get; set; }
        public Object? RefObject { get; set; }
        public PickList? PickList { get; set; }

    }
}
