using LiteEntity;
using LiteEntity.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Util;
using Util.Helper;
using WpfBase.MessageBox;
using WpfBase.Mvvm;

namespace WpfApp1
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly LiteDB liteDB;
        private KPModel selected;
        private ObservableCollection<KPModel> kPModels;

        public ObservableCollection<KPModel> KPModels { get => kPModels; set { kPModels = value; PCEH(); } }


        public ICommand ChangeCommand => new CommandBase(o => Selected = o as KPModel);

        public ICommand AddCommand => new CommandBase(async o =>
        {
            string str = await DialogInput.Show("增加知识点");
            if (str == null) return;
            if (KPModels.Select(l => l.Name).Contains(str))
            {
                await DialogOK.Show("该知识点已存在");
                return;
            }
            KPModel kPModel = new KPModel { Name = str, ID = GuidHelper.GenerateKey() };
            KPModels.Add(kPModel);
            liteDB.Add(EntityCopyHelper.Mapper<KP, KPModel>(kPModel));
            await liteDB.SaveChangesAsync();
        });

        public ICommand EditCommand => new CommandBase(async o =>
        {
            string str = await DialogInput.Show("修改知识点", Selected.Name);
            if (str == null) return;
            if (str == Selected.Name) return;
            if (KPModels.Select(l => l.Name).Contains(str))
            {
                await DialogOK.Show("该知识点已存在");
                return;
            }
            Selected.Name = str;
            KP kP = new KP { ID = Selected.ID, Name = str };
            liteDB.Entry(kP).Property(l => l.Name).IsModified = true;
            await liteDB.SaveChangesAsync();
        });

        public ICommand DeleteCommand => new CommandBase(async o =>
        {
            bool bo = await DialogYesNo.Show("删除知识点");
            if (!bo) return;
            Selected = null;
            KP kP = await liteDB.Set<KP>().Include(l => l.Extends).Include(l => l.Preconditions).FirstOrDefaultAsync(l => l.ID == Selected.ID);
            kP.Extends.ForEach(l => liteDB.Remove(l));
            kP.Preconditions.ForEach(l => liteDB.Remove(l));
            liteDB.Remove(kP);
            await liteDB.SaveChangesAsync();
        });

        public ICommand AddExtend => new CommandBase(async o =>
        {
            KPModel kPModel = o as KPModel;
            if (kPModel == null || Selected == null) return;
            if (kPModel.Name == Selected.Name) return;
            if (Selected.Extends.Contains(kPModel))
            {
                Selected.Extends.Remove(kPModel);
            }
            else
            {
                Selected.Extends.Add(kPModel);
                Selected.Preconditions.Remove(kPModel);
            }
        });

        public ICommand AddPrecondition => new CommandBase(async o =>
        {
            KPModel kPModel = o as KPModel;
            if (kPModel == null || Selected == null) return;
            if (kPModel.Name == Selected.Name) return;
            if (Selected.Preconditions.Contains(kPModel))
            {
                Selected.Preconditions.Remove(kPModel);
            }
            else
            {
                Selected.Preconditions.Add(kPModel);
                Selected.Extends.Remove(kPModel);
            }
        });

        public KPModel Selected
        {
            get => selected; set
            {
                selected = value;
                PCEH();
                if (value != null) GetItem();
            }
        }

        public MainWindowViewModel()
        {
            liteDB = new LiteDB();

            KPModels = new ObservableCollection<KPModel>(liteDB.Set<KP>().Select(l => new KPModel { ID = l.ID, Name = l.Name }).ToList());
        }

        public void GetItem()
        {
            List<string> extends = liteDB.Set<KPR>().Where(l => l.TargetID == Selected.ID).Select(l => l.OriginID).ToList();
            List<string> preconditions = liteDB.Set<KPR>().Where(l => l.OriginID == Selected.ID).Select(l => l.TargetID).ToList();

            Selected.Extends = new ObservableCollection<KPModel>(kPModels.Where(l => extends.Contains(l.ID)));
            Selected.Preconditions = new ObservableCollection<KPModel>(kPModels.Where(l => preconditions.Contains(l.ID)));

        }
    }
}
