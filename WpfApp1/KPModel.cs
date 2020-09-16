using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfBase.Mvvm;

namespace WpfApp1
{
    public class KPModel : ViewModelBase
    {
        private string iD;
        private string name;
        private ObservableCollection<KPModel> extends;
        private ObservableCollection<KPModel> preconditions;
        private bool isSelect;

        public string ID { get => iD; set { iD = value; PCEH(); } }

        public string Name { get => name; set { name = value; PCEH(); } }

        public bool IsSelect { get => isSelect; set { isSelect = value; PCEH(); } }


        public ObservableCollection<KPModel> Extends { get => extends; set { extends = value; PCEH(); } }


        public ObservableCollection<KPModel> Preconditions { get => preconditions; set { preconditions = value; PCEH(); } }
    }
}
