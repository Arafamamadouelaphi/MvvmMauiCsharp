using Mvue.ViewModel;
using ViewModel;

namespace Mvue.Pages;

public partial class DetailChampion : ContentPage
{
	public DetailChampion(ChampionDetailViewModel champion)
	{
		InitializeComponent();
		BindingContext = champion;
	}
}
