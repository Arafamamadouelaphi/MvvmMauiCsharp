namespace Mvue;
using Mvue.Pages;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		//MainPage = new();
		MainPage = new AppShell();
        //MainPage = new NewPage1();
     //MainPage = new AjoutChampion();
    }
}

