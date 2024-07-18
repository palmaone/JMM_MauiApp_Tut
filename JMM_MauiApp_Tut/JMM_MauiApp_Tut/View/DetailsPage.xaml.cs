using JMM_MauiApp_Tut.ViewModel;

namespace JMM_MauiApp_Tut.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(MonkeyDetailsViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}