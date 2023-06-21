using Model;
using Mvue.ViewModel;
using ViewModel;
namespace Mvue.Pages;

public partial class AjoutChampion : ContentPage
{
   
    public AjoutChampion(EditChampionViewModel vm)
	{
		InitializeComponent();
        
        BindingContext = vm;
    }
    //public List<string> AllClasses => Enum.GetNames(typeof(ChampionClass)).ToList();
}
