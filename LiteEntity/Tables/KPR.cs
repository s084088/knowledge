using System;
using System.Collections.Generic;
using System.Text;

namespace LiteEntity.Tables
{
    public class KPR : DbBase
    {
        private KP origin;
        private KP target;

        public virtual KP Origin { get => origin; set { origin = value; PCEH(); } }
        public string OriginID { get; set; }


        public virtual KP Target { get => target; set { target = value; PCEH(); } }
        public string TargetID { get; set; }
    }
}
