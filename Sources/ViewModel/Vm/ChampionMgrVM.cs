using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Immutable;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model;
using ViewModel.Vm;

namespace ViewModel
{
    public class ChampionMgrVM : INotifyPropertyChanged
    {
        public ICommand NextPageCommand { get; private set; }
        public ICommand DeleteChampionCommand { get; }
        public ObservableCollection<ChampionVM> Champions { get; }

        public IDataManager DataManager
        {
            get => _dataManager;
            set
            {
                if (_dataManager == value) return;
                _dataManager = value;
                OnPropertyChanged();
            }
        }
        private IDataManager _dataManager
        { get; set; }


        public ChampionMgrVM(IDataManager dataManager)
        {
            DataManager = dataManager;
            Champions = new ObservableCollection<ChampionVM>();
            DeleteChampionCommand = new Command<ChampionVM>(async (ChampionVM obj) => await DeleteChampion(obj));
            LoadChampions(index, Count).ConfigureAwait(false);
            PropertyChanged += ChampionMgrVM_PropertyChanged;
            PropertyChanged += ChampionMgrm_PropertyChanged;
            Total = this.DataManager.ChampionsMgr.GetNbItems().Result;

        }

        public int nombrepage(int GetNbItems, int count)
        {
            int result = GetNbItems / count;

            if (result < 0) return result + 1;
            else
                return result;
        }
        private async void ChampionMgrVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Index))
            {
                await LoadChampions(index, Count);
            }
        }

        public int PageTotale { get { return this.total / Count + ((this.total % Count) > 0 ? 1 : 0); } }

        private int total;

        public int Total
        {
            get => total;
            private set
            {
                total = value;
                OnPropertyChanged();
            }
        }

        public int Index
        {
            get => index;
            set
            {
                if (index == value) return;
                index = value;
                OnPropertyChanged();
            }
        }

        private int index = 1;

        public int Count
        {
            get;
            set;
        } = 5;
        //public int PageTotale { get { return this.total / Count + ((this.total % Count) > 0 ? 1 : 0); } }
        //private int count = 5;
        //public int Count
        //{
        //    get => count;
        //    private set
        //    {
        //        count = value;
        //    }
        //}


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task LoadChampions(int Index, int Count)
        {
            Champions.Clear();
            var modelChampions = await DataManager.ChampionsMgr.GetItems(Index - 1, Count);

            foreach (var champion in modelChampions)
            {
                Champions.Add(new ChampionVM(champion));
            }
        }
        private async void ChampionMgrm_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Index))
            {
                Champions.Clear();
                await LoadChampions(Index, Count);
            }
        }
        public async void SaveChampion(EditableChampionVM editableChampionVM, ChampionVM? championVM)
        {
            if (editableChampionVM is null) return;
            if (!editableChampionVM.IsNew)
            {
                editableChampionVM.SaveChampion();
                var champ = await DataManager.ChampionsMgr.UpdateItem(championVM.Model, editableChampionVM.Model.Model);
            }
            else
            {
                editableChampionVM.SaveChampion();
                var champ = await DataManager.ChampionsMgr.AddItem(editableChampionVM.Model.Model);
                if (champ is null)
                {
                    var tata = "sfs";
                }
                updatePagination();
            }

        }

        public async Task DeleteChampion(ChampionVM champion)
        {
            if (champion is null) return;
            if (!Champions.Contains(champion)) return;
            await DataManager.ChampionsMgr.DeleteItem(champion.Model);
            updatePagination();

        }

        private async void updatePagination()
        {


            await LoadChampions(this.Index, Count);

            // Total = this.DataManager.ChampionsMgr.GetNbItems().Result;
            if (Champions.Count == 0)
            {
                this.Index = this.Index - 1;
                await LoadChampions(this.Index, Count);
            }
            this.Total = this.DataManager.ChampionsMgr.GetNbItems().Result;
            OnPropertyChanged(nameof(this.Champions));

            OnPropertyChanged(nameof(PageTotale));

        }


    }
}

