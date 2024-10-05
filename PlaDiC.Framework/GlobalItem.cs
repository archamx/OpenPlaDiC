using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaDiC.Framework
{
    public class GlobalItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public object Tag { get; set; }
        public string Text { get; set; }
        public int Index { get; set; }
        public string Url { get; set; }
        public string Data { get; set; }

        public GlobalItem() { }


        public GlobalItem(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
