using System;
using System.Collections.Generic;
using System.Text;

namespace LiteEntity.Tables
{
    public class KPR : DbBase
    {
        public virtual KP Origin { get; set; }
        public string OriginID { get; set; }


        public virtual KP Target { get; set; }
        public string TargetID { get; set; }
    }
}
