using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiteEntity.Tables
{
    public class KP : DbBase
    {
        private string name;
        private string text;
        private ObservableCollection<EKP> eKPs;
        private ObservableCollection<KPR> extends;
        private ObservableCollection<KPR> preconditions;

        /// <summary>
        /// 知识的名称
        /// </summary>
        [MaxLength(63)]
        public string Name { get => name; set { name = value; PCEH(); } }

        /// <summary>
        /// 此知识的说明
        /// </summary>
        [MaxLength(1024)]
        public string Text { get => text; set { text = value; PCEH(); } }

        /// <summary>
        /// 此知识包含的实体
        /// </summary>
        public virtual ObservableCollection<EKP> EKPs { get => eKPs; set { eKPs = value; PCEH(); } }

        /// <summary>
        /// 此知识的衍生知识
        /// </summary>
        public virtual ObservableCollection<KPR> Extends { get => extends; set { extends = value; PCEH(); } }

        /// <summary>
        /// 此知识的前置知识
        /// </summary>
        public virtual ObservableCollection<KPR> Preconditions { get => preconditions; set { preconditions = value; PCEH(); } }
    }
}
