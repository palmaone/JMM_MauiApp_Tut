using System.ComponentModel;

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
            OnPropertyChanged(nameof(IsBusy));
            //OnPropertyChanged("IsBusy");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

