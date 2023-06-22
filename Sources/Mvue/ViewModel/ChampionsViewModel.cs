using System;
using ViewModel;
using ViewModel.Vm;
using Mvue.Pages;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Mvue.ViewModel;

public  partial class ChampionsViewModel : ObservableObject
{
    public Command EditChampionCommand { get; }
    public ChampionMgrVM ChampionMgrVM { get; }

    public ChampionsViewModel(ChampionMgrVM championMgr)
    {
        ChampionMgrVM = championMgr;
    }
    [RelayCommand]
    private void PushToDetail(ChampionVM champion)
    {
    
        Shell.Current.Navigation.PushAsync(new DetailChampion(new ChampionDetailViewModel(ChampionMgrVM, champion)));
    }

    [RelayCommand]
    private void AddChampion()
    {
        Shell.Current.Navigation.PushAsync(new AjoutChampion(new EditChampionViewModel(ChampionMgrVM, new EditableChampionVM(null), null)));
    }
}
