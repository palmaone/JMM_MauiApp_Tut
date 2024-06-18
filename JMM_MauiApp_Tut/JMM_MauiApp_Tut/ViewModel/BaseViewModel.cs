using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace JMM_MauiApp_Tut.ViewModel;
[INotifyPropertyChanged]
public partial class BaseViewModel
{

    public BaseViewModel() { }
    private bool isBusy;
    private string title;

    
}

