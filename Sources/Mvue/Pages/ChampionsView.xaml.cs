namespace Mvue.Pages;
using Mvue.ViewModel;
using ViewModel;

public partial class ChampionsView : ContentPage
{
	public ChampionsViewModel ChampionsViewModel { get; }
	public ChampionsView(ChampionsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        ChampionsViewModel = vm;
	}
}
