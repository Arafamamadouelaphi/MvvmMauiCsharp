using System;
using Mvue.Pages;
using ViewModel;
using ViewModel.Vm;

namespace Mvue.ViewModel
{
	public class ChampionDetailViewModel
	{
		public ChampionDetailViewModel(ChampionMgrVM manager,ChampionVM championVm)
		{
			ChampionVM = championVm;
			EditChampionCommand = new Command(EditChampion);
			Manager = manager;
		}
		public ChampionVM ChampionVM { get; }
		private ChampionMgrVM Manager;
		public Command EditChampionCommand { get; }

		private async void EditChampion()
		{
			await Shell.Current.Navigation.PushAsync(new AjoutChampion(new EditChampionViewModel(Manager, new EditableChampionVM(ChampionVM), ChampionVM)));
		}
	}
}

