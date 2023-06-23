using System;
using ViewModel;
using ViewModel.Vm;
using Mvue.Pages;
using System.Windows.Input;

namespace Mvue.ViewModel;

public class ChampionsViewModel
{
    public Command NextPageCommand { get; private set; }
    public Command PreviousPageCommand { get; }
    public Command EditChampionCommand { get; }
    public ChampionMgrVM ChampionMgrVM { get; }

    public ChampionsViewModel(ChampionMgrVM championMgr)
    {
        ChampionMgrVM = championMgr;
        PushToDetailCommand = new Command<ChampionVM>(PushToDetail);
        NextPageCommand = new Command(NextPage,CanExecuteNext);
        PreviousPageCommand = new Command(PreviousPage, CanExecutePrevious);
        AddChampionCommand = new Command(Addchampion);
        EditChampionCommand = new Command(execute: (champioon) => { EditChampion((ChampionVM)champioon); });
    }
    private void NextPage()
    {
        ChampionMgrVM.Index++;
        RefreshCanExecute();

    }
    private void PreviousPage()
    {
        ChampionMgrVM.Index--;
        RefreshCanExecute();
    }
    private bool CanExecutePrevious()
    {
        return ChampionMgrVM.Index > 1;
    }
    private bool CanExecuteNext()
    {
        var val = (this.ChampionMgrVM.Index) < this.ChampionMgrVM.PageTotale;
        return val;
    }
    void RefreshCanExecute()
    {

        PreviousPageCommand.ChangeCanExecute();
        NextPageCommand.ChangeCanExecute();

    }

    public Command PushToDetailCommand { get; }
    public Command AddChampionCommand { get; }

    private void PushToDetail(ChampionVM champion)
    {
    //    if (!ChampionMgrVM.Champions.Contains(champion)) return;
    //    ChampionMgrVM.Champions.Remove(champion);
        Shell.Current.Navigation.PushAsync(new DetailChampion(new ChampionDetailViewModel(ChampionMgrVM, champion)));
    }

    private void Addchampion()
    {
        Shell.Current.Navigation.PushAsync(new AjoutChampion(new EditChampionViewModel(ChampionMgrVM, new EditableChampionVM(null), null)));
    }
    private async void EditChampion(ChampionVM championvvm)
    {
        await Shell.Current.Navigation.PushAsync(new AjoutChampion(new EditChampionViewModel(ChampionMgrVM, new EditableChampionVM(championvvm), championvvm)));
    }

    //public Command AddChampion { get; set; }

    //private void AddChampion(Tuple<string, int> tuple)
    //{
    //    ChampionVM.AddCharacteristics(tuple);
    //}
}
