using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using ViewModel.Vm;

namespace ViewModel
{
    public partial class ChampionMgrVM : ObservableObject
    {   
     
        public ObservableCollection<ChampionVM> Champions { get; }

        public IDataManager DataManager
        {
            get => _dataManager;
            set
            {
                _dataManager = value;
               
            }
        }
       
        private IDataManager _dataManager { get; set; }

        [RelayCommand(CanExecute = nameof(CanExecuteNext))]
        private void NextPage()
        {
            Index++;

        }
        [RelayCommand(CanExecute = nameof(CanExecutePrevious))]
        private void PreviousPage()
        {
            Index--;
        }
        private bool CanExecutePrevious()
        {
            return Index > 1;
        }
        private bool CanExecuteNext()
        {
            var val = (this.Index) < this.PageTotale;
            return val;
        }
        public ChampionMgrVM(IDataManager dataManager)
        {
            DataManager = dataManager;
            Champions = new ObservableCollection<ChampionVM>();
            LoadChampions(index, Count).ConfigureAwait(false);
            PropertyChanged += ChampionMgrm_PropertyChanged;
            Total = this.DataManager.ChampionsMgr.GetNbItems().Result;

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
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(PreviousPageCommand), nameof(NextPageCommand))]

        private int index = 1;
        public int Count
        {
            get;
            set;
        } = 5;

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
        [RelayCommand]
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

