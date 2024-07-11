using JMM_MauiApp_Tut.ViewModel;

namespace JMM_MauiApp_Tut;

public partial class MainPage : ContentPage
{

	public MainPage(MonkeysViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	
}

