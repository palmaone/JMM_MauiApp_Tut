using CommunityToolkit.Mvvm.ComponentModel;
using JMM_MauiApp_Tut.Model;

namespace JMM_MauiApp_Tut.ViewModel;

[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{
    public MonkeyDetailsViewModel()
    {
    }

    [ObservableProperty]
    Monkey? monkey;
}

