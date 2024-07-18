using JMM_MauiApp_Tut.View;

namespace JMM_MauiApp_Tut;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //nameof(DetailsPage) == "DetailsPage"
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
	}
}
