using JMM_MauiApp_Tut.Model;
using System.Collections.ObjectModel;
using JMM_MauiApp_Tut.Services;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;

namespace JMM_MauiApp_Tut.ViewModel
{
    public partial class MonkeysViewModel : BaseViewModel
    {
        MonkeyService monkeyService;
        public ObservableCollection<Monkey> Monkeys { get; } = new();

        //public Command GetMonkeysCommand { get; }

        public MonkeysViewModel(MonkeyService monkeyService) 
        {
            Title = "Monkey Finder";
            this.monkeyService = monkeyService;
            //GetMonkeysCommand = new Command(async () => await GetMonkeysAsync();

        }

        [RelayCommand]
        async Task GetMonkeysAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var monkeys = await monkeyService.GetMonkeys();

                if (Monkeys.Count != 0)  Monkeys.Clear();

                //This might be a problem if the add operation needs
                // to run for thousands or more list elements
                foreach (var monkey in monkeys) 
                    Monkeys.Add(monkey);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!",
                    $"Unable to get monkeys: {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
