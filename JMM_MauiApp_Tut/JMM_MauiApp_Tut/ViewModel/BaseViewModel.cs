using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JMM_MauiApp_Tut.ViewModel;
public class BaseViewModel : INotifyPropertyChanged
{
    private bool isBusy;
    private string title;

    public bool IsBusy
    {
        get => isBusy;
        set
        {
            if(isBusy == value) return;

            isBusy = value;
            //We can call OnPropertyChanged() witout passing any params
            //thanks to annotation in line 26 [CallerMemberName]
            OnPropertyChanged();
            //OnPropertyChanged(nameof(IsBusy));
            //OnPropertyChanged("IsBusy");
        }
    }
    
    public bool IsNotBusy => !isBusy;

    public string Title
    {
        get => title;
        set
        {
            if (title == value) return;
            title = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsNotBusy));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName]string? name =null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

