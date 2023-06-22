using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mvue.Pages;
using ViewModel;
using ViewModel.Vm;

namespace Mvue.ViewModel
{
	public partial class ChampionDetailViewModel : ObservableObject
    {
		public ChampionDetailViewModel(ChampionMgrVM manager,ChampionVM championVm)
		{
			ChampionVM = championVm;
			Manager = manager;
		}
		public ChampionVM ChampionVM { get; }
		private ChampionMgrVM Manager;
	//public Command EditChampionCommand { get; }
        [RelayCommand]
        private async void EditChampion()
		{
			await Shell.Current.Navigation.PushAsync(new AjoutChampion(new EditChampionViewModel(Manager, new EditableChampionVM(ChampionVM),ChampionVM)));
		}
	}
}

