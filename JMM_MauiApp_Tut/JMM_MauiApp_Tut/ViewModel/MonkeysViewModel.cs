using JMM_MauiApp_Tut.Model;
using System.Collections.ObjectModel;
using JMM_MauiApp_Tut.Services;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using JMM_MauiApp_Tut.View;
using CommunityToolkit.Mvvm.ComponentModel;

namespace JMM_MauiApp_Tut.ViewModel
{
    public partial class MonkeysViewModel : BaseViewModel
    {
        MonkeyService monkeyService;
        public ObservableCollection<Monkey> Monkeys { get; } = new();

        //public Command GetMonkeysCommand { get; }
        IConnectivity connectivity;
        IGeolocation geolocation;
        public MonkeysViewModel(
            MonkeyService monkeyService, 
            IConnectivity connectivity,
            IGeolocation geolocation
          ) 
        {
            Title = "Monkey Finder";
            this.monkeyService = monkeyService;
            this.connectivity = connectivity;
            this.geolocation = geolocation;
            //GetMonkeysCommand = new Command(async () => await GetMonkeysAsync();

        }

        [ObservableProperty]
        bool isRefreshing;

        [RelayCommand]
        async Task GetClosestMonkeyAsync()
        {
            if(IsBusy || Monkeys.Count == 0) return;

            try
            {
                var location = await geolocation.GetLastKnownLocationAsync();


                if (location is null)
                {
                    location = await geolocation.GetLocationAsync(
                            new GeolocationRequest
                            {
                                DesiredAccuracy = GeolocationAccuracy.Medium,
                                Timeout = TimeSpan.FromSeconds(30),
                            }   
                        );
                }

                if (location is null) return;

                var first = Monkeys.OrderBy(m => 
                    location.CalculateDistance(
                        m.Latitude, 
                        m.Longitude, 
                        DistanceUnits.Miles
                    )
                ).FirstOrDefault();

                if (first is null) return;

                await Shell.Current.DisplayAlert(
                    "Closest Monkey",
                    $"{first.Name} in {first.Location}",
                    "OK"
                );
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error",
                    $"Unable to get closest Monkey: {ex.Message}", "Ok");
            }
        }

        [RelayCommand]
        async Task GoToDetailsAsync(Monkey monkey) 
        {
            if (monkey == null) return;

            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?id{monkey.Name}", true, 
                    new Dictionary<string, object>
                    {
                        {"Monkey", monkey}
                    });
        }

        [RelayCommand]
        async Task GetMonkeysAsync()
        {
            if (IsBusy) return;

            try
            {
                if(connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet issue",
                        $"Check your internet and try again", "OK");
                    return;
                }
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
                IsRefreshing = false;
            }
        }
    }
}
