using System;
using System.Collections.Generic;
using System.Text;

namespace LiteEntity.Tables
{
    public class KP:DbBase
    {
        public  string Name { get; set; }

        public virtual ICollection<KPR> Extends { get; set; }

        public virtual ICollection<KPR> Preconditions { get; set; }
    }
}
